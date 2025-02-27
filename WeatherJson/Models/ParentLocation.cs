namespace WeatherAPI.Models
{
    public class ParentLocation
    {
        public string Title { get; set; } = string.Empty;
        public string LocationType { get; set; } = string.Empty;
        public int Woeid { get; set; }
        public string LattLong { get; set; } = string.Empty;
    }
}
