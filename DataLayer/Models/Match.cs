using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Match
    {
        [JsonPropertyName("venue")]
        public required string Venue { get; set; }

        [JsonPropertyName("location")]
        public required string Location { get; set; }

        [JsonPropertyName("status")]
        public required string Status { get; set; }

        [JsonPropertyName("time")]
        public required string Time { get; set; }

        [JsonPropertyName("fifa_id")]
        public required string FifaId { get; set; }

        [JsonPropertyName("weather")]
        public required Weather Weather { get; set; }

        [JsonPropertyName("attendance")]
        public required string Attendance { get; set; }

        [JsonPropertyName("officials")]
        public required string[] Officials { get; set; }

        [JsonPropertyName("stage_name")]
        public required string StageName { get; set; }

        [JsonPropertyName("home_team_country")]
        public required string HomeTeamCountry { get; set; }

        [JsonPropertyName("away_team_country")]
        public required string AwayTeamCountry { get; set; }

        [JsonPropertyName("datetime")]
        public DateTime Datetime { get; set; }

        [JsonPropertyName("winner")]
        public required string Winner { get; set; }

        [JsonPropertyName("winner_code")]
        public required string WinnerCode { get; set; }

        [JsonPropertyName("home_team")]
        public required TeamResult HomeTeam { get; set; }

        [JsonPropertyName("away_team")]
        public required TeamResult AwayTeam { get; set; }

        [JsonPropertyName("home_team_events")]
        public required TeamEvent[] HomeTeamEvents { get; set; }

        [JsonPropertyName("away_team_events")]
        public required TeamEvent[] AwayTeamEvents { get; set; }

        [JsonPropertyName("home_team_statistics")]
        public required TeamStatistics HomeTeamStatistics { get; set; }

        [JsonPropertyName("away_team_statistics")]
        public required TeamStatistics AwayTeamStatistics { get; set; }

        [JsonPropertyName("last_event_update_at")]
        public DateTime LastEventUpdateAt { get; set; }

        [JsonPropertyName("last_score_update_at")]
        public DateTime? LastScoreUpdateAt { get; set; }
    }
}
