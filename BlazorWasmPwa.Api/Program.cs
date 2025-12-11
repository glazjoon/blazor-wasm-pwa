using BlazorWasmPwa.Configuration;
using BlazorWasmPwa.Feature.WeatherForecast;
using ServiceDefaults1;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        // Assume this API is only called from our Blazor WASM
        // And that the PWA is hosted separately
        var pwaUrl = builder.Configuration.GetValue<string>($"{ServiceName.Pwa}_HTTPS")
            ?? throw new InvalidOperationException("PWA URL is not configured.");
        
        policy.WithOrigins(pwaUrl)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors();

app.MapWeatherForecastEndpoint();

app.Run();