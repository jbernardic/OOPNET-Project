using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public abstract class ImageHelper()
    {
        private static readonly string AssetsPath = PathHelper.GetRelativePath("assets");
        public static string? GetPlayerImage(string playerName)
        {
            try
            {
                string[] files = Directory.GetFiles(AssetsPath);

                foreach (var file in files)
                {
                    if (Path.GetFileNameWithoutExtension(file).Equals(playerName, StringComparison.OrdinalIgnoreCase))
                    {
                        return file;
                    }
                }
            }
            catch { }


            return null;
        }

        public void UploadPlayerImage(string playerName, string imagePath)
        {
            if (!File.Exists(imagePath))
                throw new FileNotFoundException("Source image not found", imagePath);

            if (!Directory.Exists(AssetsPath))
                Directory.CreateDirectory(AssetsPath);

            string extension = Path.GetExtension(imagePath);
            string destinationPath = Path.Combine(AssetsPath, playerName + extension);

            File.Copy(imagePath, destinationPath, overwrite: true);
        }


    }
}
