namespace BlazorWasmPwa.Contracts.WeatherForecast;

public class WeatherForecastDto
{
    public required DateOnly Date { get; init; }
    public required int TemperatureC { get; init; }
    public required int TemperatureF { get; init; }
    public required string TemperatureCategory { get; init; }
}