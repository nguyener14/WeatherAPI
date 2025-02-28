using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class WeatherData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("weather_state_name")]
        public string WeatherStateName { get; set; } = string.Empty;

        [JsonProperty("weather_state_abbr")]
        public string WeatherStateAbbr { get; set; } = string.Empty;

        [JsonProperty("wind_direction_compass")]
        public string WindDirectionCompass { get; set; } = string.Empty;

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("applicable_date")]
        public DateTime ApplicableDate { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("the_temp")]
        public double TheTemp { get; set; }

        [JsonProperty("wind_speed")]
        public long WindSpeed { get; set; }

        [JsonProperty("wind_direction")]
        public long WindDirection { get; set; }

        [JsonProperty("air_pressure")]
        public double AirPressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("predictability")]
        public int Predictabilty { get; set; }

    }
}
