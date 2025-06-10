using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    public class SettingsManager
    {
        private static readonly string settingsPath = Path.Combine(Application.StartupPath, "settings.txt");
        private static UserSettings? settings;

        public static UserSettings GetSettings()
        {
            settings ??= new UserSettings(settingsPath);
            return settings;
        }
    }
}
