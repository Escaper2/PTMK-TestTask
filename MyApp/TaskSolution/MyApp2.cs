using Application.Services.Implementations;
using DataAccess;
using Microsoft.Extensions.Configuration;
using MyApp.Extensions;

namespace MyApp.TaskSolution;

public static class MyApp2
{
    public static void Solve(string fullName, DateOnly birthDate, string sex)
    {
        var options = new ConfigurationBuilder().GetDatabaseContextOptions();

        var service = new PersonService(new DatabaseContext(options));

        service.CreatePerson(fullName, birthDate, sex);
        
        Console.WriteLine("Person was added to database");

    }
}