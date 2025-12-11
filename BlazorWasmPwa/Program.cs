using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasmPwa;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddOptions<AppSettings>().Bind(builder.Configuration.GetSection(nameof(AppSettings)));

var apiBaseUrl = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>()?.ApiBaseUrl 
    ?? throw new InvalidOperationException("API base URL is not configured.");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new(apiBaseUrl) });

await builder.Build().RunAsync();