﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Cli;
using WeatherApp.Extensions;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;

// TODO: Enable switch between providers (using CLI arguments)
// OPTIONAL: Create extensions for the following
services.AddCliServices(builder.Configuration["UseDefault"]!);

using var host = builder.Build();
await host.Services.GetRequiredService<WeatherCli>().RunAsync(args);