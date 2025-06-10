using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Weather
    {
        [JsonPropertyName("humidity")]
        public required string Humidity { get; set; }

        [JsonPropertyName("temp_celsius")]
        public required string TempCelsius { get; set; }

        [JsonPropertyName("temp_farenheit")]
        public required string TempFarenheit { get; set; }

        [JsonPropertyName("wind_speed")]
        public required string WindSpeed { get; set; }

        [JsonPropertyName("description")]
        public required string Description { get; set; }
    }
}
