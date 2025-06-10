using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TeamResult
    {
        [JsonPropertyName("country")]
        public required string Country { get; set; }

        [JsonPropertyName("code")]
        public required string Code { get; set; }

        [JsonPropertyName("goals")]
        public int Goals { get; set; }

        [JsonPropertyName("penalties")]
        public int Penalties { get; set; }
    }
}
