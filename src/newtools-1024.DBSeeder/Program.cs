using newtools_1024.DBSeeder;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.AddNpgsqlDbContext<SampleDbContext>("postgresdb");
var host = builder.Build();
host.Run();