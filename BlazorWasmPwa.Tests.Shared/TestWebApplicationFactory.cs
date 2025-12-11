using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorWasmPwa.Tests.Shared;

public class TestWebApplicationFactory<TProgram>(string? environment = null)
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment(environment ?? Environments.Development);

        builder.ConfigureAppConfiguration((context, config) =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["BLAZOR-WASM-PWA_HTTPS"] = "https://localhost:5001"
            });
        });

        builder.ConfigureServices(services =>
        {
            services.Configure<HttpsRedirectionOptions>(options => { options.HttpsPort = null; });
        });
    }
}