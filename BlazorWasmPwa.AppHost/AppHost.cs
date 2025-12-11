using BlazorWasmPwa.Configuration;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var pwa = builder.AddProject<Projects.BlazorWasmPwa>(ServiceName.Pwa);

builder.AddProject<BlazorWasmPwa_Api>(ServiceName.Api)
    .WithReference(pwa);

builder.Build().Run();