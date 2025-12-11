using BlazorWasmPwa.Contracts.WeatherForecast;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BlazorWasmPwa.Feature.WeatherForecast;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapWeatherForecastEndpoint(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/weather-forecast")
            .WithTags("Weather");

        group.MapGet("/", GetWeather)
            .WithName("GetWeatherForecast");

        return endpoints;
    }

    private static async Task<IResult> GetWeather([AsParameters] GetWeatherForecastRequest request)
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                WeatherForecast.Create
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55)
                ))
            .ToArray();

        var forecastDtos = forecast.Select(f => f.MapToDto()).ToArray();

        return Results.Ok(forecastDtos);
    }
}