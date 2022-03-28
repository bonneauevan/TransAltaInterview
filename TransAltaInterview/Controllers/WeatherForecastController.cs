using Microsoft.AspNetCore.Mvc;
using System.Text;
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
        public async Task<ActionResult<MontlySummary>> GetMonthlySummaryAsync(string month, int year)
        {
            if (month == null || year == null)
            {
                return BadRequest();
            }

            var result = await _weatherForecastService.GetMonthlySummaryAsync(month, year);

            if (result?.HasError == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.Exception);
            }

            return Ok(result.Result);
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

        [HttpGet("downloadWeatherData", Name = nameof(DownloadWeatherDataAsync))]
        public async Task<ActionResult> DownloadWeatherDataAsync()
        {
            var result = await _weatherForecastService.GetWeatherRecordsAsStringAsync();

            if (result?.HasError == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.Exception);
            }

            var bytes = Encoding.ASCII.GetBytes(result.Result);

            return File(bytes, "text/csv", Path.GetFileName("test.csv"));

        }
    }
}