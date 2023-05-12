using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DataAccess;

public class DatabaseContext : DbContext
{

    private string connectionString;
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) 
        :base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Person> Persons { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>().Property(x => x.Sex).HasMaxLength(10);
        builder.Entity<Person>().Property(x => x.FullName).HasMaxLength(100);
    }
    

    
}