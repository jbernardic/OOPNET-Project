namespace DataLayer
{
    public class UserSettings(string filePath)
    {

        public enum Gender
        {
            Male,
            Female
        }

        public enum Language
        {
            Croatian,
            English
        }

        public Gender SelectedGender { get; set; } = Gender.Male;
        public Language SelectedLanguage { get; set; } = Language.Croatian;

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

                if (key.Equals("Gender", StringComparison.OrdinalIgnoreCase) &&
                    Enum.TryParse(value, out Gender gender))
                {
                    SelectedGender = gender;
                }

                if (key.Equals("Language", StringComparison.OrdinalIgnoreCase) &&
                    Enum.TryParse(value, out Language language))
                {
                    SelectedLanguage = language;
                }
            }
        }

        public void Save()
        {
            var lines = new string[]
            {
            $"Gender={SelectedGender}",
            $"Language={SelectedLanguage}"
            };

            File.WriteAllLines(FilePath, lines);
        }
    }
}
