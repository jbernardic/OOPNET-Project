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

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                SettingsManager.GetSettings().Load();
                OpenAppWindow();
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserSettings settings = SettingsManager.GetSettings();
            settings.SelectedCategory = rbWomen.IsChecked == true ? UserSettings.Category.Women : UserSettings.Category.Men;
            settings.SelectedLanguage = rbCroatian.IsChecked == true ? UserSettings.Language.Croatian : UserSettings.Language.English;
            settings.Save();

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