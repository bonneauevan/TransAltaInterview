using Microsoft.AspNetCore.Mvc;
using TransAltaInterview.Interfaces;
using TransAltaInterview.Models;

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

        [HttpGet("getMonthlySummary", Name =nameof(GetMonthlySummaryAsync))]
        public async Task<ActionResult<MontlySummary>> GetMonthlySummaryAsync(string month, int day, int year)
        {

        }

        [HttpGet("getWeatherData", Name =nameof(GetWeatherDataAsync))]
        public async Task<ActionResult<WeatherRecord>> GetWeatherDataAsync()
        {
            var result = await _weatherForecastService.GetWeatherDataAsync();

            if (result?.HasError == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.Exception);
            }

            return Ok(result?.Result);
        }

        [HttpGet("updateWeatherData", Name =nameof(UpdateWeatherDataAsync))]
        public async Task<ActionResult> UpdateWeatherDataAsync()
        {
            var result = await _weatherForecastService.UpdateWeatherDataAsync();

            if (result?.HasError == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.Exception);
            }

            return Ok();
        }
    }
}