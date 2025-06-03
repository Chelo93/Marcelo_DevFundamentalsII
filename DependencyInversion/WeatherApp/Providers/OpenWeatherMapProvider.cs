namespace WeatherApp.Providers;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Services;

// DTO class to match the expected JSON structure
public class ForecastDto
{
    public MainDto? Main { get; set; }
}

public class MainDto
{
    public double Temp { get; set; }
}

public class OpenMateoProvider : IWeatherProvider
{
    private readonly HttpService _httpService;

    public OpenMateoProvider(HttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<double> GetTodayAsync(string latitude, string longitude)
    {
        // Construct the API URL using the provided latitude and longitude
        string url = $"https://historical-forecast-api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m";
        
        // Fetch the weather data from the API
        var weatherData = await _httpService.GetFromJsonAsync<ForecastDto>(url);    
        // Return the current temperature in Celsius
        return weatherData?.Main?.Temp ?? 0.0;
    }
}