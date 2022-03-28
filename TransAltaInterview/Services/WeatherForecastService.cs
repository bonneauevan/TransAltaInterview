using AutoMapper;
using System.Text.Json;
using TransAltaInterview.DbContexts;
using TransAltaInterview.Interfaces;
using TransAltaInterview.Models;

namespace TransAltaInterview.Services
{
    public class WeatherForecastService: IWeatherForecastService
    {
        private readonly TransAltaDbContext _dbContext;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        public WeatherForecastService(TransAltaDbContext transAltaDbContext,
            IHttpClientFactory httpClientFactory,
            IMapper autoMapper)
        {
            _dbContext = transAltaDbContext;
            _httpClientFactory = httpClientFactory;
            _mapper = autoMapper;
        }

        public async Task<ServiceResult<WeatherRecord>> GetWeatherDataAsync()
        {
            try {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "API");

                var requestMessage = new HttpRequestMessage();
                requestMessage.Method = HttpMethod.Get;
                requestMessage.RequestUri = new Uri("https://www.theweathernetwork.com/api/data/caab0049/cm");

                var responseMessage = await httpClient.SendAsync(requestMessage);

                var content = await responseMessage.Content.ReadAsStringAsync();

                var weatherNetworkReport = JsonSerializer.Deserialize<WeatherNetworkReport>(content);

                var weatherRecord = _mapper.Map<WeatherRecord>(weatherNetworkReport);

                weatherRecord.TheoreticalPower = GetTheoreticalPower(weatherRecord.WindSpeed);

                return new ServiceResult<WeatherRecord>(weatherRecord);
            }
            catch (Exception ex)
            {
                return new ServiceResult<WeatherRecord>(null, ex);
            }
        }

        public async Task<ServiceResult> UpdateWeatherDataAsync()
        {
            try
            {
                var weatherDataResult = await GetWeatherDataAsync();

                if (weatherDataResult?.HasError == true)
                {
                    return new ServiceResult(weatherDataResult.Exception);
                }

                _dbContext.Add<WeatherRecord>(weatherDataResult?.Result);
                _dbContext.SaveChanges();

                return new ServiceResult();
            }
            catch (Exception ex)
            {
                return new ServiceResult<WeatherRecord>(null, ex);
            }
        }

        public async Task<ServiceResult<MontlySummary>> GetMonthlySummaryAsync(string month, int day, int year)
        {

        }

        private double GetTheoreticalPower(int windspeed)
        {
            // Windspeed in m/s rounded to the nearest .5
            var windspeed_meters = Math.Round((windspeed / 3.6)*2)/2;

            if (windspeed_meters < 4 || windspeed_meters > 25)
            {
                return 0;
            }

            if (windspeed_meters >= 14)
            {
                return 1800;
            }

            switch (windspeed_meters)
            {
                case 4: return 1;
                case 4.5: return 40;
                case 5: return 79;
                case 5.5: return 145.5;
                case 6: return 212;
                case 6.5: return 308.5;
                case 7: return 405;
                case 7.5: return 527.5;
                case 8: return 650;
                case 8.5: return 781.5;
                case 9: return 913;
                case 9.5: return 1061.5;
                case 10: return 1210;
                case 10.5: return 1368.5;
                case 11: return 1527;
                case 11.5: return 1633.5;
                case 12: return 1740;
                case 12.5: return 1766;
                case 13: return 1792;
                case 13.5: return 1796;
                    default: return 0;
            }

        }
    }
}
