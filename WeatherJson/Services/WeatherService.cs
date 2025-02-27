using Newtonsoft.Json;
using System.Text.RegularExpressions;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly Dictionary<string, string> _cityUrls;
        private const string OutputFilePath = "wwwroot/weather_report.json";

        public WeatherService(HttpClient httpClient) 
        {
            _httpClient = httpClient;

            _cityUrls = new Dictionary<string, string>
            {
                { "Los Angeles", "URL_FOR_LOS_ANGELES" },
                { "New York", "URL_FOR_NEW_YORK" },
                { "London", "URL_FOR_LONDON" }
            };
        }

        public async Task<string> GenerateWeatherReport()
        {
            var weatherData = await GetWeatherData();
            var lowestMinTemps = GetLowestMinTemps(weatherData);

            string jsonResult = JsonConvert.SerializeObject(lowestMinTemps);

            var directory = Path.GetDirectoryName(OutputFilePath);
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            await File.WriteAllTextAsync(OutputFilePath, jsonResult);

            return jsonResult;
        }

        private async Task<List<CityWeather>> GetWeatherData()
        {
            var allWeatherData = new List<CityWeather>();

            foreach(var (city, url) in _cityUrls)
            {
                var response = await _httpClient.GetStringAsync(url);
                var weatherReponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

                foreach(var weather in weatherReponse.ConsolidatedWeather)
                {
                    var cityWeatherData = new CityWeather
                    {
                        City = city,
                        Date = weather.ApplicableDate,
                        MinTemp = weather.MinTemp,
                        MaxTemp = weather.MaxTemp,
                        FullWeatherData = weather,
                    };
                    allWeatherData.Add(cityWeatherData);
                }
            }
            return allWeatherData;
        }

        private List<DailyCityWeather> GetLowestMinTemps(List<CityWeather> allWeatherData)
        {
            return allWeatherData.GroupBy(d => d.Date).
                Select(group =>
                {
                    var lowestTempCity = group.OrderBy(w => w.MinTemp).First();
                    return new DailyCityWeather
                    {
                        Date = lowestTempCity.Date,
                        MinTemp = lowestTempCity.MinTemp,
                        MaxTemp = lowestTempCity.MaxTemp,
                        City = lowestTempCity.City,
                        FullWeatherData = lowestTempCity.FullWeatherData
                    };
                }).OrderBy(d => d.Date).ToList();
        }
    }
}
