using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            LoadData();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            var msgWindow = new MessageWindow()
            {
                Owner = this
            };
            msgWindow.ShowDialog();
            if (!msgWindow.YesAnswer)
            {
                e.Cancel = true;
            }
        }

        private async void LoadData()
        {
            var resolution = UserSettings.GetInstance().SelectedResolution;
            if (resolution != null)
            {
                if (resolution.IsFullscreen)
                {
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    WindowState = WindowState.Normal;
                    Width = resolution.Width;
                    Height = resolution.Height;
                }
            }

            matches = await Repository.Get(UserSettings.GetInstance().SelectedCategory).GetMatches() ?? [];
            results = await Repository.Get(UserSettings.GetInstance().SelectedCategory).GetResults() ?? [];
            var teams = await Repository.Get(UserSettings.GetInstance().SelectedCategory).GetTeams();
            
            cbHome.ItemsSource = teams;
            cbHome.SelectedValue = UserSettings.GetInstance().FavouriteTeam;
        }

        private void LoadAwayData()
        {
            var awayTeams = (matches ?? [])
                .Where(match => match.HomeTeam.Code == HomeTeamCode)
                .Select(match => match.AwayTeam.Code)
                .ToList();
            cbAway.ItemsSource = awayTeams;
        }

        private void LoadPlayers()
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

                txtScore.Text = $"{selectedMatch.HomeTeam.Goals} : {selectedMatch.AwayTeam.Goals}";
            }
        }

        private void cbHome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserSettings.GetInstance().FavouriteTeam = HomeTeamCode;
            UserSettings.GetInstance().Save();

            cbAway.SelectedIndex = -1;

            LoadAwayData();

        }

        //show home info
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var r = results.Where(r => r.FifaCode == HomeTeamCode);

            if(r.Any())
            {
                var window = new TeamWindow(r.First())
                {
                    Owner = this
                };
                window.ShowDialog();
            }


        }

        //show away info
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var r = results.Where(r => r.FifaCode == AwayTeamCode);

            if (r.Any())
            {
                var window = new TeamWindow(r.First())
                {
                    Owner = this
                };
                window.ShowDialog();
            }
        }

        //settings btn
        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            var window = new SettingsWindow()
            {
                Owner = this
            };
            window.ShowDialog();
            LoadData();
        }
    }
}
