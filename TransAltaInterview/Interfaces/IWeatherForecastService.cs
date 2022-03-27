using TransAltaInterview.Models;

namespace TransAltaInterview.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<ServiceResult<string>> TestServiceMethodAsync(string input);

        Task<ServiceResult> WriteRecordAsync(WeatherRecord record);
    }
}
