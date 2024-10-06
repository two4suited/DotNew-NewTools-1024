using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.AddNpgsqlDbContext<SampleDbContext>("postgresdb");
builder.Services.AddMapster();
builder.Services.AddSingleton<ICodeGenerationRegister,MapsterConfiguration>();
builder.Services.AddCarter(configurator: cfg => { cfg.WithValidatorLifetime(ServiceLifetime.Scoped); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseReDoc(c =>
{
    c.DocumentTitle = "REDOC API Documentation";
    c.SpecUrl = "/swagger/v1/swagger.json";
}); 

app.MapDefaultEndpoints();
app.MapCarter();

app.Run();


