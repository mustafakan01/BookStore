using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependecyInjection;
using Microsoft.Extensions.Logging;
using WebApi.DbOperations;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hot = CreateHostBuilder(args).Build();

            using(var scope=host.Services.CreateScope())
            {
                var services=scope.serviceProvider;
                DataGenerator.Initialize(services);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
