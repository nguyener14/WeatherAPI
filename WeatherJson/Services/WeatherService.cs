using Newtonsoft.Json;
using System.Text.RegularExpressions;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly Dictionary<string, string> _cityUrls;
        private readonly ILogger<WeatherService> _logger;
        private const string OutputFilePath = "wwwroot/weather_report.json";

        public WeatherService(HttpClient httpClient, ILogger<WeatherService> logger, IConfiguration configuration) 
        {
            _httpClient = httpClient;
            _logger = logger;

            _cityUrls = new Dictionary<string, string>
            {
                { "Los Angeles", configuration["WeatherApiUrls:LosAngeles"] },
                { "New York", configuration["WeatherApiUrls:NewYork"] },
                { "London", configuration["WeatherApiUrls:London"] }
            };
        }

        public async Task<string> GenerateWeatherReport()
        {
            try
            {
                _logger.LogInformation("Generating Report");
                var weatherData = await GetWeatherData();
                var lowestMinTemps = GetLowestMinTemps(weatherData);

                string jsonResult = JsonConvert.SerializeObject(lowestMinTemps);

                var directory = Path.GetDirectoryName(OutputFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                _logger.LogInformation($"Weather report successfully generated.");

                await File.WriteAllTextAsync(OutputFilePath, jsonResult);

                return jsonResult;
            }
            catch(Exception ex)
            {
                _logger.LogError("There was an error generating the report.");
                return string.Empty;
            }
            
        }

        private async Task<List<CityWeather>> GetWeatherData()
        {
            var allWeatherData = new List<CityWeather>();

            foreach(var (city, url) in _cityUrls)
            {
                try
                {
                    var response = await _httpClient.GetStringAsync(url);
                    var weatherReponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

                    foreach (var weather in weatherReponse.ConsolidatedWeather)
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
                catch (HttpRequestException ex)
                {
                    _logger.LogError(ex, "Failed to fetch data from {City}", city);
                }
                catch(JsonException ex)
                {
                    _logger.LogError(ex, "Failed to parse JSON for {City}", city);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error for {City}", city);
                }
                
            }
            return allWeatherData;
        }

        private List<DailyCityWeather> GetLowestMinTemps(List<CityWeather> allWeatherData)
        {
            try
            {
                _logger.LogInformation("Processing weather data...");
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to process weather data.");
                return new List<DailyCityWeather>();
            }
            
        }
    }
}
