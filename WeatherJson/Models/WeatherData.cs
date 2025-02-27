namespace WeatherAPI.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string WeatherStateName { get; set; } = string.Empty;
        public string WeatherStateAbbr { get; set; } = string.Empty;
        public string WindDirectionCompass { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime ApplicableDate { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public double TheTemp { get; set; }
        public long WindSpeed { get; set; }
        public long WindDirection { get; set; }
        public double AirPressure { get; set; }
        public int Humidity { get; set; }
        public long Visibility { get; set; }
        public int Predictabilty { get; set; }

    }
}
