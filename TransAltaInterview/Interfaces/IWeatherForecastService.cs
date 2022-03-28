using TransAltaInterview.Models;

namespace TransAltaInterview.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<ServiceResult<WeatherRecord>> GetWeatherDataAsync();

        Task<ServiceResult> UpdateWeatherDataAsync();

        Task<ServiceResult<MontlySummary>> GetMonthlySummaryAsync(string month, int day, int year);
    }
}
