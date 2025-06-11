using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public static List<Player> GetPlayersInMatch(Match match, bool homeTeam = true)
        {
            if (homeTeam)
            {
                var startingEleven = match.HomeTeamStatistics.StartingEleven;
                var substitutesEleven = match.HomeTeamStatistics.Substitutes;
                return startingEleven.Union(substitutesEleven).ToList();
            }
            else
            {
                var startingEleven = match.AwayTeamStatistics.StartingEleven;
                var substitutesEleven = match.AwayTeamStatistics.Substitutes;
                return startingEleven.Union(substitutesEleven).ToList();
            }

        }

        public async Task<List<Player>> GetPlayers(string fifaCode)
        {
            var match = (await GetMatches(fifaCode))?.FirstOrDefault();
            if (match == null)
            {
                return [];
            }

            return GetPlayersInMatch(match);
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

        public async Task<List<MatchRank>> GetMatchRanks(string fifaCode)
        {
            var matches = await GetMatches(fifaCode);
            if (matches == null) return [];

            List<MatchRank> rankList = [.. matches.Select(e => new MatchRank
            {
                Location = e.Location,
                Attendance = int.Parse(e.Attendance),
                AwayTeamCountry = e.AwayTeamCountry,
                HomeTeamCountry = e.HomeTeamCountry
            })];

            rankList.Sort();

            return rankList;
        }

        public async Task<List<PlayerRank>> GetPlayerRanks(string fifaCode)
        {
            var players = await GetPlayers(fifaCode);
            var matches = await GetMatches(fifaCode);

            if (matches == null || players == null) return [];

            Dictionary<string, PlayerRank> rankMap = [];

            foreach(var match in matches)
            {

                var playersInMatch = GetPlayersInMatch(match, true).Union(GetPlayersInMatch(match, false));
                foreach(var player in playersInMatch)
                {
                    if (!rankMap.TryGetValue(player.Name, out PlayerRank? rank))
                    {
                        rank = new PlayerRank() { PlayerName = player.Name };
                        rankMap.Add(player.Name, rank);
                    }
                    rank.AppearanceCount++;
                }

                var events = match.AwayTeamEvents.Union(match.HomeTeamEvents);
                foreach (var e in events)
                {

                    var rank = rankMap[e.Player];

                    if (e.TypeOfEvent == "goal")
                    {
                        rank.GoalCount++;
                    }
                    else if (e.TypeOfEvent == "yellow-card")
                    {
                        rank.YellowCardCount++;
                    }
                }
            }

            List<PlayerRank> values = [.. rankMap.Values];
            values.Sort();

            return values;
        }
    }
}
