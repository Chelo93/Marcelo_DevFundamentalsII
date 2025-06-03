using WeatherApp.Interfaces;

namespace WeatherApp.Cli;

public class WeatherCli(IWeatherProvider provider)
{
  private readonly IWeatherProvider _provider = provider;

  private bool TryValidateArgs(string[] args, out double latitude, out double longitude)
  {
    latitude = 0;
    longitude = 0;
    if (args.Length == 0) return false;

    var coordinates = args[0].Split(',');
    if (coordinates.Length != 2) return false;

    return double.TryParse(coordinates[0], out latitude) &&
           double.TryParse(coordinates[1], out longitude);
  }

  public async Task RunAsync(string[] args)
  {
    // Validate arguments
    if (!TryValidateArgs(args, out double latitude, out double longitude))
    {
      Console.WriteLine("Invalid coordinates format. Please use: latitude,longitude");
      return;
    }

    var temperature = await _provider.GetTodayAsync(latitude.ToString(), longitude.ToString());
    Console.WriteLine($"Today weather is: {temperature} Celsius");
  }
}