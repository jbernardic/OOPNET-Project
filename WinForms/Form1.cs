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
            settings.SelectedGender = rbFemale.Checked ? Gender.Female : Gender.Male;
            settings.SelectedLanguage = rbCroatian.Checked ? Language.Croatian : Language.English;
            settings.Save();
            Close();
        }
    }
}
