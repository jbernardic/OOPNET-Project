using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {

        private List<DataLayer.Models.Match> matches = [];
        private List<DataLayer.Models.Result> results = [];
        private DataLayer.Models.Match? selectedMatch;

        private string HomeTeamCode { get { return cbHome.SelectedValue?.ToString() ?? ""; } }
        private string AwayTeamCode { get { return cbAway.SelectedValue?.ToString() ?? ""; } }

        public AppWindow()
        {
            InitializeComponent();

            LoadMatches();
            LoadHomeData();
        }

        private async void LoadMatches()
        {
            matches = await Repository.Get(SettingsManager.GetSettings().SelectedCategory).GetMatches() ?? [];
            results = await Repository.Get(SettingsManager.GetSettings().SelectedCategory).GetResults() ?? [];
        }

        private async void LoadHomeData()
        {
            var teams = await Repository.Get(SettingsManager.GetSettings().SelectedCategory).GetTeams();
            cbHome.ItemsSource = teams;
            cbHome.SelectedValue = SettingsManager.GetSettings().FavouriteTeam;
        }

        private void LoadAwayData()
        {
            var awayTeams = (matches ?? [])
                .Where(match => match.HomeTeam.Code == HomeTeamCode)
                .Select(match => match.AwayTeam.Code)
                .ToList();
            cbAway.ItemsSource = awayTeams;
        }

        private async void LoadPlayers()
        {
            if (selectedMatch == null) return;

            var homePlayers = selectedMatch.HomeTeamStatistics.StartingEleven;
            var awayPlayers = selectedMatch.AwayTeamStatistics.StartingEleven;

            PositionPlayers(homePlayers, true);
            PositionPlayers(awayPlayers, false);
        }

        private void PositionPlayers(Player[] players, bool isHomeTeam)
        {

            if (isHomeTeam)
            {
                HomeGoalie.Children.Clear();
                HomeDefender.Children.Clear();
                HomeMidfield.Children.Clear();
                HomeForward.Children.Clear();
            }
            else
            {
                AwayGoalie.Children.Clear();
                AwayDefender.Children.Clear();
                AwayMidfield.Children.Clear();
                AwayForward.Children.Clear();
            }

            foreach (var player in players)
            {
                var ctrl = new PlayerControl(player.Name, player.ShirtNumber);
                ctrl.MouseLeftButtonUp += (s, e) => ShowPlayerDetails(player);

                if (isHomeTeam)
                {

                    if (player.Position == "Goalie") HomeGoalie.Children.Add(ctrl);
                    if (player.Position == "Defender") HomeDefender.Children.Add(ctrl);
                    if (player.Position == "Midfield") HomeMidfield.Children.Add(ctrl);
                    if (player.Position == "Forward") HomeForward.Children.Add(ctrl);
                }
                else
                {
                    if (player.Position == "Goalie") AwayGoalie.Children.Add(ctrl);
                    if (player.Position == "Defender") AwayDefender.Children.Add(ctrl);
                    if (player.Position == "Midfield") AwayMidfield.Children.Add(ctrl);
                    if (player.Position == "Forward") AwayForward.Children.Add(ctrl);
                }
            }
        }

        private void ShowPlayerDetails(Player player)
        {
            if (selectedMatch == null) return;

            var playerWindow = new PlayerWindow(player, selectedMatch)
            {
                Owner = this
            };
            playerWindow.ShowDialog();
        }

        private void cbAway_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var match = matches.Where(
                match => match.HomeTeam.Code == HomeTeamCode &&
                match.AwayTeam.Code == AwayTeamCode
                );

            if(match.Any())
            {
                selectedMatch = match.First();
                LoadPlayers();
            }


        }

        private void cbHome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingsManager.GetSettings().FavouriteTeam = HomeTeamCode;
            SettingsManager.GetSettings().Save();
            LoadAwayData();

        }
    }
}
