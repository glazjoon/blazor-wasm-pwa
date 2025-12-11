using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var pwa = builder.AddProject<BlazorWasmPwa>("blazor-wasm-pwa");

builder.AddProject<BlazorWasmPwa_Api>("blazor-wasm-pwa-api")
    .WithReference(pwa);

builder.Build().Run();