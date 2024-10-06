using Sheridan.Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres").WithPgAdmin();
var postgresdb = postgres.AddDatabase("postgresdb");

var seeder = builder.AddProject<Projects.newtools_1024_DBSeeder>("dbseeder")
    .WaitFor(postgresdb)
    .WithReference(postgresdb);

var apiService = builder.AddProject<Projects.newtools_1024_ApiService>("apiservice")
    .WaitFor(seeder)
    .WithReference(postgresdb);

builder.AddProject<Projects.newtools_1024_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
