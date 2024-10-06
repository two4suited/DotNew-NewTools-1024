using Bogus;
using Microsoft.EntityFrameworkCore;
using newtools1024.ApiService.Data.Entities;
using Person = newtools1024.ApiService.Data.Entities.Person;


namespace newtools_1024.DBSeeder;

public class Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            using(var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SampleDbContext>();
                await dbContext.Database.EnsureCreatedAsync(stoppingToken);
                await LoadData(dbContext);
            }
        }
    }

    private async Task LoadData(SampleDbContext dbContext)
    {
        if (!dbContext.People.Any())
        {
            var persons = GenerateFakePersons(10);
            await dbContext.People.AddRangeAsync(persons);
            await dbContext.SaveChangesAsync();
        }
    }
    private List<Person> GenerateFakePersons(int count)
    {
        var petFaker = new Faker<Pet>()
            .RuleFor(p => p.Id, f => 0) 
            .RuleFor(p => p.Name, f => f.Name.FirstName())
            .RuleFor(p => p.Type, f => f.PickRandom<PetType>())
            .RuleFor(p => p.Breed, f => f.PickRandom<Breed>())
            .RuleFor(p => p.DateOfBirth, f => f.Date.Past(10).ToShortDateString());

        var personFaker = new Faker<Person>()
            .RuleFor(p => p.Id, f => 0) 
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.DateOfBirth, f => f.Date.Past(30).ToShortDateString())
            .RuleFor(p => p.Pets, f => petFaker.Generate(f.Random.Int(1, 3)));

        return personFaker.Generate(count);
    }
}