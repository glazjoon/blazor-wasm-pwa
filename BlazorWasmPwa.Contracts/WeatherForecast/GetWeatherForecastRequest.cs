namespace BlazorWasmPwa.Contracts.WeatherForecast;

public class GetWeatherForecastRequest
{
    public DateOnly? ForDate { get; init; }
}