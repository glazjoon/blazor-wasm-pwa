using System.Net.Http.Json;
using BlazorWasmPwa.Contracts.WeatherForecast;
using BlazorWasmPwa.Tests.Shared;

namespace BlazorWasmPwa.Feature.WeatherForecast.Tests;

[TestFixture]
public class GetWeatherForecastTests : IntegrationTest
{
    [Test]
    public async Task GetWeatherForecast_ReturnsForecasts()
    {
        // Act
        var actual = await HttpClient.GetFromJsonAsync<WeatherForecastDto[]>("/api/weather-forecast");
        
        // Assert
        Assert.That(actual, Has.Length.GreaterThan(0));
    }
}