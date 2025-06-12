using System.Linq;

namespace DataLayer
{
    public class UserSettings(string filePath)
    {

        public enum Category
        {
            Men,
            Women
        }

        public enum Language
        {
            Croatian,
            English
        }

        public class Resolution
        {

            public bool IsFullscreen => Width == 0 && Height == 0;
            public int Width { get; set; }
            public int Height { get; set; }

            public override string ToString()
            {
                if (IsFullscreen)
                {
                    return "fullscreen";
                }
                return $"{Width}x{Height}";
            }

            public static Resolution FromString(string res)
            {
                if (res == "fullscreen")
                {
                    return new Resolution
                    {
                        Width = 0,
                        Height = 0,
                    };
                }
                
                var widthHeight = res.Split("x");

                return new Resolution
                {
                    Width = int.Parse(widthHeight[0]),
                    Height = int.Parse(widthHeight[1])
                };
            }
        }

        public Category SelectedCategory { get; set; } = Category.Men;
        public Language SelectedLanguage { get; set; } = Language.Croatian;
        public Resolution? SelectedResolution { get; set; } = null;
        public string? FavouriteTeam { get; set; } = null;
        public HashSet<string> FavouritePlayers { get; set; } = [];

        public string FilePath { get; set; } = filePath;

        public void Load()
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException();

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('=');
                if (parts.Length != 2)
                    continue;

                var key = parts[0].Trim();
                var value = parts[1].Trim();

                if (key.Equals("Category", StringComparison.OrdinalIgnoreCase) &&
                    Enum.TryParse(value, out Category category))
                {
                    SelectedCategory = category;
                }

                if (key.Equals("Language", StringComparison.OrdinalIgnoreCase) &&
                    Enum.TryParse(value, out Language language))
                {
                    SelectedLanguage = language;
                }

                if (key.Equals("FavouriteTeam", StringComparison.OrdinalIgnoreCase))
                {
                    FavouriteTeam = value;
                }

                if(key.Equals("FavouritePlayers", StringComparison.OrdinalIgnoreCase))
                {
                    FavouritePlayers = [.. value.Split(",")];
                    FavouritePlayers.Remove("");
                }

                if (key.Equals("Resolution", StringComparison.OrdinalIgnoreCase))
                {
                    SelectedResolution = Resolution.FromString(value);
                }
            }
        }

        public void Save()
        {
            var lines = new string[]
            {
            $"Category={SelectedCategory}",
            $"Language={SelectedLanguage}",
            $"FavouriteTeam={FavouriteTeam}",
            $"FavouritePlayers={String.Join(",", FavouritePlayers)}",
            $"Resolution={SelectedResolution}"
            };

            File.WriteAllLines(FilePath, lines);
        }
    }
}
