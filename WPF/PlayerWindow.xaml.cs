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
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public PlayerWindow(Player player, Match match)
        {
            InitializeComponent();

            var stats = match.GetPlayerStats(player);

            lblInfo.Text = $"{player.Name}\n{player.ShirtNumber}\nCaptain? {player.Captain}\nGoals: {stats.GoalCount}\n" +
                $"Yellow cards: {stats.YellowCardCount}";
        }
    }
}
