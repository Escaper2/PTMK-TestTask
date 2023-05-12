using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyApp.Extensions;

public static class ApplicationExtensions
{
    public static IConfigurationRoot GetConfig(this ConfigurationBuilder builder)
    {
        var config = builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        return config;
    }
    
    public static DbContextOptions<DatabaseContext> GetDatabaseContextOptions(this ConfigurationBuilder builder)
    {
        var config = GetConfig(builder);
        
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseNpgsql(config.GetConnectionString("DefaultConnection"))
            .Options;

        return options;
    }
}