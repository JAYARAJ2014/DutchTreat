using System;
using DutchTreat.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            SeedDatabase(host);


            host.Run();
        }

        private static void SeedDatabase(IWebHost host)
        {
            var scopeFacatory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFacatory.CreateScope())
            {
                var seeder = host.Services.GetService<DutchSeeder>();
                seeder.Seed();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
    }
}
