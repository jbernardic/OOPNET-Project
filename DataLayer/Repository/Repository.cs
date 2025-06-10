using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.UserSettings;

namespace DataLayer.Repository
{
    public abstract class Repository(Category category)
    {
        public Category Category { get; } = category;

        public static Repository Get(Category category)
        {
            bool loadThroughApi = true;
            return loadThroughApi ? new ApiRepository(category) : new FileRepository(category);
        }

        public abstract Task<List<Result>?> GetResults();
        public abstract Task<List<Match>?> GetMatches(string? fifaCode=null);

        public async Task<List<Player>> GetPlayers(string fifaCode)
        {
            var match = (await GetMatches(fifaCode))?.FirstOrDefault();
            if (match == null)
            {
                return [];
            }

            var startingEleven = match.HomeTeamStatistics.StartingEleven;
            var substitutesEleven = match.HomeTeamStatistics.Substitutes;

            return startingEleven.Union(substitutesEleven).ToList();
        }

        public async Task<List<string>> GetTeams()
        {
            var results = await GetResults();

            if (results == null) return [];

            HashSet<string> teams = [];
            foreach (var item in results)
            {
                teams.Add(item.FifaCode);
            }

            return [.. teams];
        }
    }
}
