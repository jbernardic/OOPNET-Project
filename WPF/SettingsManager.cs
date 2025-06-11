using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    public class SettingsManager
    {
        private static readonly string settingsPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.txt");
        private static UserSettings? settings;

        public static UserSettings GetSettings()
        {
            settings ??= new UserSettings(settingsPath);
            return settings;
        }
    }
}
