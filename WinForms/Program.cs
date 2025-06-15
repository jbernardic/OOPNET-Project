using DataLayer;

namespace WinForms
{
    internal static class Program
    {



        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();



            var settings = UserSettings.GetInstance();
            try
            {
                settings.Load();
            }
            catch (FileNotFoundException) {
                new Form1().ShowDialog();
            }


            Application.Run(new AppForm());
        }
    }
}