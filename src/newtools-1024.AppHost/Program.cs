var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.newtools_1024_ApiService>("apiservice");

builder.AddProject<Projects.newtools_1024_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
