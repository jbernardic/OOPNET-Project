﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TeamStatistics
    {
        [JsonPropertyName("country")]
        public required string Country { get; set; }

        [JsonPropertyName("attempts_on_goal")]
        public int AttemptsOnGoal { get; set; }

        [JsonPropertyName("on_target")]
        public int OnTarget { get; set; }

        [JsonPropertyName("off_target")]
        public int OffTarget { get; set; }

        [JsonPropertyName("blocked")]
        public int Blocked { get; set; }

        [JsonPropertyName("woodwork")]
        public int Woodwork { get; set; }

        [JsonPropertyName("corners")]
        public int Corners { get; set; }

        [JsonPropertyName("offsides")]
        public int Offsides { get; set; }

        [JsonPropertyName("ball_possession")]
        public int BallPossession { get; set; }

        [JsonPropertyName("pass_accuracy")]
        public int PassAccuracy { get; set; }

        [JsonPropertyName("num_passes")]
        public int NumPasses { get; set; }

        [JsonPropertyName("passes_completed")]
        public int PassesCompleted { get; set; }

        [JsonPropertyName("distance_covered")]
        public int DistanceCovered { get; set; }

        [JsonPropertyName("balls_recovered")]
        public int BallsRecovered { get; set; }

        [JsonPropertyName("tackles")]
        public int Tackles { get; set; }

        [JsonPropertyName("clearances")]
        public int Clearances { get; set; }

        [JsonPropertyName("yellow_cards")]
        public int YellowCards { get; set; }

        [JsonPropertyName("red_cards")]
        public int RedCards { get; set; }

        [JsonPropertyName("fouls_committed")]
        public int? FoulsCommitted { get; set; }

        [JsonPropertyName("tactics")]
        public required string Tactics { get; set; }

        [JsonPropertyName("starting_eleven")]
        public required Player[] StartingEleven { get; set; }

        [JsonPropertyName("substitutes")]
        public required Player[] Substitutes { get; set; }
    }
}
