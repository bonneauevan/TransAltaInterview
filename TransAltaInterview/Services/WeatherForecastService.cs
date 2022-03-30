using AutoMapper;
using System.Text;
using System.Text.Json;
using TransAltaInterview.DbContexts;
using TransAltaInterview.Interfaces;
using TransAltaInterview.Models;
using Microsoft.VisualBasic.FileIO;

namespace TransAltaInterview.Services
{
    public class WeatherForecastService : IWeatherForecastService
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
            try
            {
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

        public async Task<ServiceResult<string>> GetWeatherRecordsAsStringAsync()
        {
            try
            {
                var records = _dbContext.WeatherRecords.Select(r => r).ToList();

                if (records == null)
                {
                    return new ServiceResult<string>(null, new FileNotFoundException());
                }

                var stringBuilder = new StringBuilder();

                stringBuilder.Append($"TimeStamp, WindSpeed, WindSpeedGust, Temperature, Humidity, TheoreticalPower{Environment.NewLine}");

                foreach (var record in records)
                {
                    stringBuilder.Append($"{record.TimeStamp},{record.WindSpeed},{record.WindSpeedGust},{record.Temperature},{record.Humidity},{record.TheoreticalPower}{Environment.NewLine}");
                }

                return new ServiceResult<string>(stringBuilder.ToString());
            }
            catch (Exception ex)
            {
                return new ServiceResult<string>(null, ex);
            }
        }

        public async Task<ServiceResult<MonthlySummary>> GetMonthlySummaryAsync(int month, int year)
        {
            try
            {
                // Get the station Id from the month and year
                var stationId = GetStationId(month, year);

                // Set up HTTP request
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "API");

                var requestMessage = new HttpRequestMessage();
                requestMessage.Method = HttpMethod.Get;
                requestMessage.RequestUri = new Uri($"https://climate.weather.gc.ca/climate_data/bulk_data_e.html?format=csv&stationID={stationId}&Year={year}&timeframe=2&submit=Download+Data");

                var responseMessage = await httpClient.SendAsync(requestMessage);

                var content = await responseMessage.Content.ReadAsStreamAsync();

                // Set up storage variables
                double maxTemp = double.MinValue;
                int maxTempDay = 0;

                double minTemp = double.MaxValue;
                int minTempDay = 0;

                int gustDays = 0;

                double totalPercip = 0;

                // Parse the csv line by line
                using (TextFieldParser parser = new TextFieldParser(content))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    // Get rid of headers
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        //Processing row
                        string[] fields = parser.ReadFields();

                        // Check if month is month we are looking for
                        if (fields[6] != String.Empty && int.Parse(fields[6]) == month)
                        {
                            // Check Max temp
                            if (fields[9] != String.Empty && double.Parse(fields[9]) >= maxTemp)
                            {
                                maxTemp = double.Parse(fields[9]);
                                maxTempDay = int.Parse(fields[7]);
                            }

                            // Check Min temp
                            if (fields[11] != String.Empty && double.Parse(fields[11]) <= minTemp)
                            {
                                minTemp = double.Parse(fields[11]);
                                minTempDay = int.Parse(fields[7]);
                            }

                            if (fields[29] != String.Empty && fields[29] != "<31" && double.Parse(fields[29]) >= 50)
                            {
                                gustDays++;
                            }

                            if (fields[23] != String.Empty)
                            {
                                totalPercip += double.Parse(fields[23]);
                            }
                        }
                    }
                }

                // If no data was overwritten, records likely arent there
                if (maxTempDay == 0)
                {
                    return new ServiceResult<MonthlySummary>(new MonthlySummary());
                }

                return new ServiceResult<MonthlySummary>(new MonthlySummary()
                {
                    ColdestDay = minTempDay,
                    ColdestTemp = minTemp,
                    HottestDay = maxTempDay,
                    HottestTemp = maxTemp,
                    MaxGustDays = gustDays,
                    TotalPercipitation = totalPercip
                });
            }
            catch (Exception ex)
            {
                return new ServiceResult<MonthlySummary>(null, ex);
            }
        }

        private int GetStationId(int month, int year)
        {
            int stationId;
            if (year >= 1960 && year <= 1979)
            {
                if (year == 1979 && month <= 6)
                {
                    stationId = 2286;
                }
                else if (year == 1979)
                {
                    stationId = 2287;
                }
                else
                {
                    stationId = 2286;
                }
            }
            else if (year <= 1994)
            {
                if (year == 1994 && month <= 3)
                {
                    stationId = 2287;
                }
                else if (year == 1994)
                {
                    stationId = 8791;
                }
                else
                {
                    stationId = 2287;
                }
            }
            else if (year <= 2011)
            {
                stationId = 8791;
            }
            else
            {
                stationId = 49368;
            }

            return stationId;
        }

        private double GetTheoreticalPower(int windspeed)
        {
            // Windspeed in m/s rounded to the nearest .5
            var windspeed_meters = Math.Round((windspeed / 3.6) * 2) / 2;

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
