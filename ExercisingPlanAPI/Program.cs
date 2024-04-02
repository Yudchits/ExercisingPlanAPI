using ExercisingPlanAPI.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ExercisingPlanAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
                var scopedFactory = builder.Services.GetService<IServiceProvider>();

                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<DbSeeder>();
                    service.SeedDataContext();
                }
            }

            builder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
