using TransAltaInterview.DbContexts;
using TransAltaInterview.Interfaces;
using TransAltaInterview.Models;

namespace TransAltaInterview.Services
{
    public class WeatherForecastService: IWeatherForecastService
    {
        private readonly TransAltaDbContext _dbContext;

        public WeatherForecastService(TransAltaDbContext transAltaDbContext)
        {
            _dbContext = transAltaDbContext;
        }

        public async Task<ServiceResult<string>> TestServiceMethodAsync(string input)
        {
            await Task.FromResult(0);
            return new ServiceResult<string>($"{input} from Service Method");
        }

        public async Task<ServiceResult> WriteRecordAsync(WeatherRecord record)
        {
            try
            {
                if (record == null)
                {
                    return new ServiceResult(new KeyNotFoundException());
                }

                _dbContext.Add(record);
                await _dbContext.SaveChangesAsync();

                return new ServiceResult();
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }
    }
}
