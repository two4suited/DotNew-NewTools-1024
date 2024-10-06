using Microsoft.EntityFrameworkCore;
using newtools1024.ApiService.Data.Entities;


public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
    }

    public DbSet<Person> People { get; set; }
    public DbSet<Pet> Pets { get; set; }
}
