using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Services;

namespace WeatherApp.Services;


public class MockWeatherProvider : IWeatherProvider
{
    private readonly HttpService _httpService;

    public MockWeatherProvider(HttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<double> GetTodayAsync(string latitude, string longitude)
    {
        // Simulate a delay for the mock provider
        await Task.Delay(1000);

        // Return a mock temperature value
        return 25.0; 
    }
}