namespace BlazorWasmPwa.Feature.WeatherForecast;

/// <summary>
/// Encapsulates business rules and domain logic related to weather predictions.
/// </summary>
internal record WeatherForecast
{
    /// <summary>
    /// The date of the weather forecast
    /// </summary>
    public DateOnly Date { get; }

    /// <summary>
    /// Temperature in Celsius
    /// </summary>
    public int TemperatureC { get; }

    /// <summary>
    /// Temperature in Fahrenheit
    /// </summary>
    public int TemperatureF => 32 + (int) Math.Ceiling(TemperatureC / 0.5556);

    private WeatherForecast(DateOnly date, int temperatureC)
    {
        Date = date;
        TemperatureC = temperatureC;
    }

    /// <summary>
    /// This is the only public way to create a WeatherForecast
    /// </summary>
    public static WeatherForecast Create(DateOnly date, int temperatureC)
    {
        ValidateTemperature(temperatureC);
        ValidateDate(date);

        // Default summary to "Unknown" to avoid null values in the domain model
        return new(date, temperatureC);
    }
    
    
    /// <summary>
    /// Categorizes temperature into temperature ranges
    /// </summary>
    public string TemperatureCategory => TemperatureC switch
    {
        < 0 => "Freezing",
        < 10 => "Cold",
        < 20 => "Mild",
        < 30 => "Warm",
        _ => "Hot",
    };

    /// <summary>
    /// Validates that temperature is within realistic conditions
    /// </summary>
    private static void ValidateTemperature(int temperatureC)
    {
        if (temperatureC is < -90 or > 60)
        {
            throw new ArgumentOutOfRangeException(nameof(temperatureC),
                "Temperature must be between -90°C and 60°C");
        }
    }

    /// <summary>
    /// Historical data should use a different model/endpoint.
    /// </summary>
    private static void ValidateDate(DateOnly date)
    {
        if (date < DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ArgumentException("Forecast date cannot be in the past", nameof(date));
        }
    }
}