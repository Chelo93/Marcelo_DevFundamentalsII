using WeatherApp.Cli;
using WeatherApp.Interfaces;
using Moq;
namespace WeatherApp.Tests.Cli;

public class TestWeatherCli
{
    [Fact]
    public async Task RunAsync_InvalidArgs_PrintsError()
    {
        var providerMock = new Mock<IWeatherProvider>();
        var cli = new WeatherCli(providerMock.Object);

        using var sw = new StringWriter();
        Console.SetOut(sw);

        await cli.RunAsync(new[] { "invalid" });

        var output = sw.ToString();
        Assert.Contains("Invalid coordinates format", output);
    }

    [Fact]
    public async Task RunAsync_ValidArgs_PrintsWeather()
    {
        var providerMock = new Mock<IWeatherProvider>();
        providerMock.Setup(static p => p.GetTodayAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(25.0);

        var cli = new WeatherCli(providerMock.Object);

        using var sw = new StringWriter();
        Console.SetOut(sw);

        await cli.RunAsync(new[] { "10.0,20.0" });

        var output = sw.ToString();
        Assert.Contains("Today weather is: 25 Celsius", output);
    }
}

