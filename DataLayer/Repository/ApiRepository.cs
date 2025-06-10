using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ApiRepository : Repository
    {

        private static string CategoryToString(Category category)
        {
            return category switch
            {
                Category.Men => "men",
                Category.Women => "women",
                _ => "",
            };
        }

        private readonly HttpClient httpClient = new();

        public override async Task<List<Match>?> GetMatches(Category category, string? fifaCode = null)
        {
            string url = $"https://worldcup-vua.nullbit.hr/{CategoryToString(category)}/matches";

            if(fifaCode != null)
            {
                url += $"/country?fifa_code=${fifaCode}";
            }

            try
            {
                return await httpClient.GetFromJsonAsync<List<Match>>(url);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public override async Task<List<Result>?> GetResults(Category category)
        {

            string url = $"https://worldcup-vua.nullbit.hr/{CategoryToString(category)}/teams/results";

            try
            {
                return await httpClient.GetFromJsonAsync<List<Result>>(url);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}
