using BlazorWasmPwa.Contracts.WeatherForecast;
using Riok.Mapperly.Abstractions;

namespace BlazorWasmPwa.Feature.WeatherForecast;

[Mapper]
internal static partial class Mappers
{
    public static partial WeatherForecastDto MapToDto(this WeatherForecast source);
}