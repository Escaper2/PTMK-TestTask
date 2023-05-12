using System.Collections.Concurrent;
using System.Text;
using Application.Services.Implementations;
using DataAccess;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using MyApp.Extensions;

namespace MyApp.TaskSolution;

public class MyApp4
{
    private static StringBuilder GetRandomName(StringBuilder sb, char letter, Random random)
    {
        var randomString = new string(Enumerable.Range(1, random.Next(1, 51))
            .Select(_ => (char)random.Next('a', 'z' + 1))
            .ToArray());
        
        sb.Append(letter);
        sb.Append(randomString);

        return sb;
    }

    private static DateOnly GetRandomDate(Random random)
    {
        var startDate = new DateTime(1970, 1, 1);
        var range = (DateTime.Today - startDate).Days;
        
        var randomDate = startDate.AddDays(random.Next(range));
        var randomDateOnly = DateOnly.FromDateTime(randomDate.Date);

        return randomDateOnly;
    }
    
    public static void Solve(PersonService service)
    {
        var random = new Random();

        var personsToAdd = new ConcurrentBag<PersonModel>();

        Parallel.ForEach(Enumerable.Range(0, 1000000), i =>
        {
            var sb = new StringBuilder();
        
            var randomLetterIndex = (i % 26) + 1;
            var randomLetter = (char)('a' + randomLetterIndex - 1);

            sb = GetRandomName(sb, randomLetter, random);
            var randomDateOnly = GetRandomDate(random);
            
            
            var randomSexIndex = (i % 2) + 1;
            var sex = randomSexIndex is 1 ? "Male" : "Female";
            

            var person = new PersonModel(Guid.NewGuid(), sb.ToString(), randomDateOnly, sex);
        
            sb.Clear();
        
            personsToAdd.Add(person);
        
        });
        
        service.CreatePersons(personsToAdd.ToList());
        
        personsToAdd.Clear();

        Parallel.ForEach(Enumerable.Range(0, 100), i =>
        {
            var sb = new StringBuilder();
            const char requiredLetter = 'f';
            
            sb = GetRandomName(sb, requiredLetter, random);
            var randomDateOnly = GetRandomDate(random);

            var person = new PersonModel(Guid.NewGuid(), sb.ToString(), randomDateOnly, "Male");

            sb.Clear();

            personsToAdd.Add(person);
            
        });
        
        service.CreatePersons(personsToAdd.ToList());
        
        Console.WriteLine("1000000 Persons with random attributes was added to database");
    }
}