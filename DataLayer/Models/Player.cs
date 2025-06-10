using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Player
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("captain")]
        public bool Captain { get; set; }

        [JsonPropertyName("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonPropertyName("position")]
        public required string Position { get; set; }
    }
}
