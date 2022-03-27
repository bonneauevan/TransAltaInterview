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

        [HttpGet("testEndpoint", Name = nameof(TestEndpointAsync))]
        public async Task<ActionResult<string>> TestEndpointAsync(string input)
        {
            var result = await _weatherForecastService.TestServiceMethodAsync(input);

            if (result?.HasError == true)
            {
                return Conflict(result.Exception);
            }

            return Ok(result.Result);
        }

        [HttpPost("writeRecord", Name=nameof(WriteRecordAsync))]
        public async Task<ActionResult> WriteRecordAsync(WeatherRecord record)
        {
            if (record == null)
            {
                return BadRequest();
            }

            var result = await _weatherForecastService.WriteRecordAsync(record);

            if (result?.HasError == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.Exception);
            }

            return Ok();
        }
    }
}