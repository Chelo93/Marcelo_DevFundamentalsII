using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Cli;
using WeatherApp.Extensions;
using WeatherApp.Interfaces;
using WeatherApp.Providers;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;

// Enable switch between providers (using CLI arguments)
// string providerName = args.Length > 0 ? args[0].ToLower() : "default";

// // Remove provider argument before passing to CLI
// var cliArgs = args.Skip(1).ToArray();

// switch (providerName)
// {
//     case "mock":
//         services.AddTransient<IWeatherProvider, MockWeatherProvider>();
//         break;
//     case "openweathermap":
//         services.AddTransient<IWeatherProvider, OpenMateoProvider>();
//         break;
//     default:
//         services.AddTransient<IWeatherProvider, DefaultWeatherProvider>();
//         break;
// }

services.AddCliServices(builder.Configuration["UseDefault"]!);

using var host = builder.Build();
await host.Services.GetRequiredService<WeatherCli>().RunAsync(args);