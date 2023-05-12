using DataAccess;
using Microsoft.Extensions.Configuration;
using MyApp.Extensions;

namespace MyApp.TaskSolution;

public static class MyApp1
{
    public static void Solve(string connectionString)
    {
        
        DatabaseCreator.CreateDatabase(connectionString!);
        
        Console.WriteLine("Database was created");
    }
}