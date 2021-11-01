using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Domain.Common;
using Infra;
using Infra.Initializer;
using Microsoft.Extensions.DependencyInjection;

namespace Soft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateAndDropDb(host);
            GetRepo.SetProvider(host.Services);
            host.Run();
        }
        private static void CreateAndDropDb(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetService<ApplicationDbContext>();
                context?.Database?.EnsureDeleted();
                context?.Database?.EnsureCreated();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetService<ILogger<Program>>();
                logger?.LogError(ex, "An error occurred creating the DB.");
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
