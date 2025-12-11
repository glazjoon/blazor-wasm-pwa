using BlazorWasmPwa.Configuration;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var pwa = builder.AddProject<BlazorWasmPwa_Client>(ServiceName.Pwa);

builder.AddProject<BlazorWasmPwa_Api>(ServiceName.Api)
    .WithReference(pwa);

builder.Build().Run();