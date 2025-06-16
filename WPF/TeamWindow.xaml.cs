using DataLayer.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        public TeamWindow(Result result)
        {
            InitializeComponent();

            lblCountry.Text = result.Country;
            lblFifaCode.Text = result.FifaCode;
            lblGamesPlayed.Text = result.GamesPlayed.ToString();
            lblWins.Text = result.Wins.ToString();
            lblLosses.Text = result.Losses.ToString();
            lblDraws.Text = result.Draws.ToString();
            lblGoalsFor.Text = result.GoalsFor.ToString();
            lblGoalsAgainst.Text = result.GoalsAgainst.ToString();
            lblGoalDifferential.Text = result.GoalDifferential.ToString();

            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var scaleX = new DoubleAnimation
            {
                From = 0.7,
                To = 2.0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            var scaleY = new DoubleAnimation
            {
                From = 0.7,
                To = 2.0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            ScaleEffect.BeginAnimation(ScaleTransform.ScaleXProperty, scaleX);
            ScaleEffect.BeginAnimation(ScaleTransform.ScaleYProperty, scaleY);
        }
    }
}
