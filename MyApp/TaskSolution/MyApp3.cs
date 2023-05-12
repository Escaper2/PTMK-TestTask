using Application.Services.Implementations;
using DataAccess;
using Microsoft.Extensions.Configuration;
using MyApp.Extensions;

namespace MyApp.TaskSolution;

public static class MyApp3
{
    public static void Solve(PersonService service)
    {

        var uniqPersons = service.GetAllWithSort();

        foreach (var person in uniqPersons)
        {
            Console.WriteLine($"{person.FullName} {person.BirthDate} {person.Sex} {person.Age}");
        }
    }
}