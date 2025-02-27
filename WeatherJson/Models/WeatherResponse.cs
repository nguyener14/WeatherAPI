using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class WeatherResponse
    {
        [JsonProperty("consolidated_weather")]
        public List<WeatherData> ConsolidatedWeather { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; } = string.Empty;

        [JsonProperty("sun_rise")]
        public DateTime SunRise { get; set; }

        [JsonProperty("sun_set")]
        public DateTime SunSet { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; } = string.Empty;

        [JsonProperty("parent")]
        public ParentLocation Parent { get; set; }

        [JsonProperty("sources")]
        public List<Source> Sources { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("location_type")]
        public string LocationType { get; set; } = string.Empty;

        [JsonProperty("woeid")]
        public int Woeid { get; set; }

        [JsonProperty("latt_long")]
        public string LattLong { get; set; } = string.Empty;

        [JsonProperty("timezone")]
        public string Timezone { get; set; } = string.Empty;

    }
}
