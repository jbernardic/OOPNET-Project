using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WPF
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private static BitmapImage? defaultImage;
        public PlayerControl(string name, int number)
        {
            InitializeComponent();
            lblName.Content = name;
            lblNumber.Content = number.ToString();

            var assetsPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets");

            var imagePath = ImageHelper.GetPlayerImage(name);
            if(imagePath != null)
            {
                SetPlayerImage(imagePath);
            }
            else
            {
                SetDefaultPlayerImage();
            }

        }

        private void SetDefaultPlayerImage()
        {
            if(defaultImage == null)
            {
                var assembly = typeof(ImageHelper).Assembly;
                string resourceName = "DataLayer.Assets.default.png";

                using Stream? stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null) throw new FileNotFoundException("Resource not found", resourceName);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                image.Freeze();
                defaultImage = image;
            }


            playerImage.Source = defaultImage;
        }

        private void SetPlayerImage(string path)
        {
            if (File.Exists(path))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // Ensures file isn't locked
                bitmap.EndInit();

                playerImage.Source = bitmap;
            }
        }
    }
}


