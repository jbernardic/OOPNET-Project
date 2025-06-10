using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TeamEvent
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type_of_event")]
        public required string TypeOfEvent { get; set; }

        [JsonPropertyName("player")]
        public required string Player { get; set; }

        [JsonPropertyName("time")]
        public required string Time { get; set; }
    }
}
