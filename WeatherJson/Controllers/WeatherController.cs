using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherAPI.Models;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("generate-json")]
        public async Task<ActionResult> GenerateJson()
        {
            var report = await _weatherService.GenerateWeatherReport();
            return Ok(report);
        }


    }
}
