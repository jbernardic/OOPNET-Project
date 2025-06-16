using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public PlayerWindow(Player player, Match match)
        {
            InitializeComponent();

            var stats = match.GetPlayerStats(player);

            lblPlayerName.Text = player.Name;
            lblShirtNumber.Text = player.ShirtNumber.ToString();
            lblCaptain.Text = player.Captain ? "Yes" : "No";
            lblGoals.Text = stats.GoalCount.ToString();
            lblYellowCards.Text = stats.YellowCardCount.ToString();

            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Opacity = 0;
            var fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.3),
                FillBehavior = FillBehavior.HoldEnd
            };

            this.BeginAnimation(OpacityProperty, fadeIn);
        }
    }
}
