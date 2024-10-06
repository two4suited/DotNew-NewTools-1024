using Carter.OpenApi;
using newtools1024.ApiService.Data.Entities;

namespace newtools1024.ApiService.Modules;

public class Person : ICarterModule
{
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/people",HandleGetAll).Produces<IEnumerable<PersonDto>>().WithTags("People").WithName("GetAllPeople").IncludeInOpenApi();
        app.MapGet("/people/{id:int}", HandleGetById).Produces<PersonDto>().WithTags("People").WithName("GetPersonById").IncludeInOpenApi();
        
    }

    private IResult HandleGetAll(HttpContext ctx, SampleDbContext dbContext)
    {
        var people = dbContext.People.ToList();
        var peopleDto = people.Select(p => p.AdaptToDto());
        return Results.Ok(peopleDto);
    }

    private IResult HandleGetById(HttpContext ctx, int id, SampleDbContext dbContext)
    {
        var person = dbContext.People.Find(id);
        if (person == null)
        {
            return Results.NotFound();
        }
        
        var personDto = person.AdaptToDto();
        return Results.Ok(personDto);
    }
}