using Microsoft.AspNetCore.Mvc;
using TransAltaInterview.Interfaces;

namespace TransAltaInterview.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("testEndpoint", Name = nameof(TestEndpointAsync))]
        public async Task<ActionResult<string>> TestEndpointAsync(string input)
        {
            var result = await _weatherForecastService.TestServiceMethodAsync(input);
            return Ok(result);
        }
    }
}