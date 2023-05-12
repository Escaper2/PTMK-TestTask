using System.Diagnostics;
using DataAccess;
using Microsoft.Extensions.Configuration;
using MyApp.Extensions;
using Npgsql;

namespace MyApp.TaskSolution;

public static class MyApp5
{
    public static void Solve(string connectionString)
    {

        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        
        DatabaseSelector.SelectPersonsWithLetterF(connectionString);

        stopwatch.Stop();

        Console.WriteLine($"Method execution time: {stopwatch.ElapsedMilliseconds } milliseconds");

    }
}