using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.UserSettings;

namespace DataLayer.Repository
{
    public class ApiRepository(Category category) : Repository(category)
    {

        private string CategoryToString()
        {
            return Category switch
            {
                Category.Men => "men",
                Category.Women => "women",
                _ => "",
            };
        }

        private readonly HttpClient httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(30),  // Crucial
            DefaultRequestHeaders =
            {
                Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
            }
        };

        public override async Task<List<Match>?> GetMatches(string? fifaCode = null)
        {
            string url = $"https://worldcup-vua.nullbit.hr/{CategoryToString()}/matches";

            if(fifaCode != null)
            {
                url += $"/country?fifa_code={fifaCode}";
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

        public override async Task<List<Result>?> GetResults()
        {

            string url = $"https://worldcup-vua.nullbit.hr/{CategoryToString()}/teams/results";

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
