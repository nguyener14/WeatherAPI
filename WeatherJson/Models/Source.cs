namespace WeatherAPI.Models
{
    public class Source
    {
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int CrawlRate { get; set; }
    }
}
