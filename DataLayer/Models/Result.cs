﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Result
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        public required string Country { get; set; }

        [JsonPropertyName("alternate_name")]
        public string? AlternateName { get; set; }

        [JsonPropertyName("fifa_code")]
        public required string FifaCode { get; set; }

        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        [JsonPropertyName("group_letter")]
        public required string GroupLetter { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("draws")]
        public int Draws { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("games_played")]
        public int GamesPlayed { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("goals_for")]
        public int GoalsFor { get; set; }

        [JsonPropertyName("goals_against")]
        public int GoalsAgainst { get; set; }

        [JsonPropertyName("goal_differential")]
        public int GoalDifferential { get; set; }
    }
}
