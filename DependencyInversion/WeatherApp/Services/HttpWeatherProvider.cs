using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class HttpWeatherProvider(HttpService httpService) : IWeatherProvider
{
  private readonly HttpService _httpService = httpService;

  public async Task<double> GetTodayAsync(string latitude, string longitude)
  {
    var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";
    var response = await _httpService.GetFromJsonAsync<ForecastDto>(url);

    // TODO: Apply validators or error handling for response
    if (response == null || response.current == null)
    {
      throw new Exception("Failed to retrieve weather data.");
    }
    return response!.current.temperature_2m;
  }
}