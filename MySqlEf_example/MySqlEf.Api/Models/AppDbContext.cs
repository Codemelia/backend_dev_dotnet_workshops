using Microsoft.EntityFrameworkCore;

namespace MySqlEf.Api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    // Maps to database table
    public DbSet<Person> Persons { get; set; }
}