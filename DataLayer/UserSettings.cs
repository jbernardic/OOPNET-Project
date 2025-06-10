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

        public Category SelectedCategory { get; set; } = Category.Men;
        public Language SelectedLanguage { get; set; } = Language.Croatian;
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
            }
        }

        public void Save()
        {
            var lines = new string[]
            {
            $"Category={SelectedCategory}",
            $"Language={SelectedLanguage}",
            $"FavouriteTeam={FavouriteTeam}",
            $"FavouritePlayers={String.Join(",", FavouritePlayers)}"
            };

            File.WriteAllLines(FilePath, lines);
        }
    }
}
