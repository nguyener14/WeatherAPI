namespace WeatherAPI.Models
{
    public class DailyCityWeather
    {
        public string City { get; set; } = string.Empty;
        public DateTime Date { get; set; } 
        public double MinTemp { get; set; } 
        public double MaxTemp { get; set; }
        public WeatherData FullWeatherData { get; set; } 
    }
}
