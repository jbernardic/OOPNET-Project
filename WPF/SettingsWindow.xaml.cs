using DataLayer;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static DataLayer.UserSettings;

namespace WPF
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            cbResolution.Items.Add(Resolution.FromString("fullscreen"));
            cbResolution.Items.Add(Resolution.FromString("768x1024"));
            cbResolution.Items.Add(Resolution.FromString("1080x1920"));
            cbResolution.Items.Add(Resolution.FromString("1440x2560"));

            cbResolution.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var msgWindow = new MessageWindow()
            {
                Owner = this
            };
            msgWindow.ShowDialog();
            if (msgWindow.YesAnswer)
            {
                UserSettings settings = SettingsManager.GetSettings();
                settings.SelectedCategory = rbWomen.IsChecked == true ? UserSettings.Category.Women : UserSettings.Category.Men;
                settings.SelectedLanguage = rbCroatian.IsChecked == true ? UserSettings.Language.Croatian : UserSettings.Language.English;
                settings.SelectedResolution = cbResolution.SelectedValue as Resolution;
                settings.Save();

                Close();
            }



        }
    }
}
