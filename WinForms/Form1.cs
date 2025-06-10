using DataLayer;
using static DataLayer.UserSettings;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {

            UserSettings settings = SettingsManager.GetSettings();
            settings.SelectedCategory = rbFemale.Checked ? Category.Women : Category.Men;
            settings.SelectedLanguage = rbCroatian.Checked ? Language.Croatian : Language.English;
            settings.Save();
            Close();
        }
    }
}
