using TransAltaInterview.Interfaces;

namespace TransAltaInterview.Services
{
    public class WeatherForecastService: IWeatherForecastService
    {

        public WeatherForecastService()
        {

        }

        public async Task<string> TestServiceMethodAsync(string input)
        {
            await Task.FromResult(0);
            return ($"{input} from Service Method");
        }
    }
}
