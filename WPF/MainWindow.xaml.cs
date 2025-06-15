using DataLayer;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DataLayer.UserSettings;

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cbResolution.Items.Add(Resolution.FromString("fullscreen"));
            cbResolution.Items.Add(Resolution.FromString("768x1024"));
            cbResolution.Items.Add(Resolution.FromString("1080x1920"));
            cbResolution.Items.Add(Resolution.FromString("1440x2560"));

            cbResolution.SelectedIndex = 0;

            try
            {
                UserSettings.GetInstance().Load();
                UserSettings.ApplyCulture();
                OpenAppWindow();
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserSettings settings = UserSettings.GetInstance();
            settings.SelectedCategory = rbWomen.IsChecked == true ? UserSettings.Category.Women : UserSettings.Category.Men;
            settings.SelectedLanguage = rbCroatian.IsChecked == true ? UserSettings.Language.Croatian : UserSettings.Language.English;
            settings.SelectedResolution = cbResolution.SelectedValue as Resolution;
            settings.Save();
            UserSettings.ApplyCulture();
            OpenAppWindow();
        }

        private void OpenAppWindow()
        {
            AppWindow appWindow = new AppWindow();
            Application.Current.MainWindow = appWindow;
            appWindow.Show();
            Close();
        }
    }
}