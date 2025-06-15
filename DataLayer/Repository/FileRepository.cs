using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class FileRepository(UserSettings.Category category) : Repository(category)
    {

        public override async Task<List<Match>?> GetMatches(string? fifaCode = null)
        {
            Stream? stream;
            if(Category == UserSettings.Category.Men)
            {
                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DataLayer.Assets.data.men.matches.json");
            }
            else
            {
                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DataLayer.Assets.data.women.matches.json");
            }

            if (stream == null)
            {
                return [];
            }

            var result = await JsonSerializer.DeserializeAsync<List<Match>>(stream) ?? [];

            return [.. result.Where(match => fifaCode == null || match.HomeTeam.Code == fifaCode)];
        }

        public override async Task<List<Result>?> GetResults()
        {
            Stream? stream;
            if (Category == UserSettings.Category.Men)
            {
                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DataLayer.Assets.data.men.results.json");
            }
            else
            {
                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DataLayer.Assets.data.women.results.json");
            }

            if (stream == null)
            {
                return [];
            }

            return await JsonSerializer.DeserializeAsync<List<Result>>(stream) ?? [];
        }
    }
}
