using System;
using System.Globalization;
using System.Linq;
using Application.Services.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Models;
using Microsoft.Extensions.Options;
using MyApp.Extensions;
using MyApp.TaskSolution;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    RunApp(args[0]);
                    break;
                case 4:
                    RunApp(args[0], args[1], args[2], args[3]);
                    break;
                default:
                    Console.WriteLine("Startup parameters are incorrect");
                    break;
            }
        }

        private static void RunApp(string appType)
        {
            var config = new ConfigurationBuilder().GetConfig();

            var connectionString = config.GetConnectionString("DefaultConnection");
            
            if (connectionString is null) Environment.Exit(-1);
            
            var options = new ConfigurationBuilder().GetDatabaseContextOptions();

            var service = new PersonService(new DatabaseContext(options));
            
            
            
            switch (appType)
            {
                case "1": 
                    MyApp1.Solve(connectionString);
                    break;
                case "3":
                    MyApp3.Solve(service);
                    break;
                case "4":
                    MyApp4.Solve(service);
                    break;
                case "5":
                    MyApp5.Solve(connectionString);
                    break;
                case "6":
                    MyApp6.Solve(connectionString);
                    break;
            }
        }

        private static void RunApp(string appType, string fullName, string dateBirth, string sex)
        {
            switch (appType)
            {
                case "2":
                    MyApp2.Solve(fullName, DateOnly.ParseExact(dateBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture), sex);
                    break;
            }
        }
    }
}