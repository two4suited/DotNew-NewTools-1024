using Carter.OpenApi;
using newtools1024.ApiService.Data.Entities;

namespace newtools1024.ApiService.Modules;

public class Person : ICarterModule
{
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/people",HandleGetAll).Produces<IEnumerable<PersonDto>>().WithTags("People").WithName("GetAllPeople").IncludeInOpenApi();
        app.MapGet("/people/{id:int}", HandleGetById).Produces<PersonDto>().WithTags("People").WithName("GetPersonById").IncludeInOpenApi();
        app.MapPost("/people", HandlePost).Produces<PersonDto>().Accepts<PersonAdd>("application/json").WithTags("People").WithName("AddPerson").IncludeInOpenApi();
        app.MapPut("/people/{id:int}", HandlePut).Produces<PersonDto>().Accepts<PersonUpdate>("application/json").WithTags("People").WithName("UpdatePerson").IncludeInOpenApi();
    }

    private IResult HandleGetAll(HttpContext ctx, SampleDbContext dbContext)
    {
        var people = dbContext.People.ToList();
        var peopleDto = people.Select(p => p.AdaptToDto());
        return Results.Ok(peopleDto);
    }
    
    private IResult HandlePut(HttpContext ctx,SampleDbContext dbContext,PersonUpdate personUpdate,int id)
    {
        var person = dbContext.People.Find(id);
        if (person == null)
        {
            return Results.NotFound();
        }
        person = personUpdate.AdaptTo(person);
        dbContext.SaveChanges();
        var personDto = person.AdaptToDto();
        return Results.Ok(personDto);
    }
    
    private IResult HandlePost(HttpContext ctx, SampleDbContext dbContext, PersonAdd personAdd)
    {
        var person = personAdd.AdaptToPerson();
        dbContext.People.Add(person);
        dbContext.SaveChanges();
        var personDto = person.AdaptToDto();
        return Results.Created($"/people/{personDto.Id}", personDto);
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