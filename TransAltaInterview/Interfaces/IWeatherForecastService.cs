using TransAltaInterview.Models;

namespace TransAltaInterview.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<ServiceResult<WeatherRecord>> GetWeatherDataAsync();

        Task<ServiceResult> UpdateWeatherDataAsync();

        Task<ServiceResult<MonthlySummary>> GetMonthlySummaryAsync(int month, int year);

        Task<ServiceResult<string>> GetWeatherRecordsAsStringAsync();
    }
}
