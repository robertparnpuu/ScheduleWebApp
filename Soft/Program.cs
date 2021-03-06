using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Domain;
using Domain.Common;
using Infra;
using Infra.Initializer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


namespace Soft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateAndDropDb(host, false);
            GetRepo.SetProvider(host.Services);
            host.Run();
        }
        private static void CreateAndDropDb(IHost host, bool newDb)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetService<ApplicationDbContext>();
                if (newDb) 
                    context?.Database?.EnsureDeleted();
                context?.Database?.EnsureCreated();
                SeedUsersAndRoles(services);
                DbInitializer.Initialize(context, newDb);                
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

        protected static void SeedUsersAndRoles(IServiceProvider s)
        {
            var roleManager = s.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = s.GetRequiredService<UserManager<ApplicationUser>>();
            UserInitializer.SeedRolesAsync(userManager, roleManager).GetAwaiter().GetResult();
            UserInitializer.SeedSuperAdminAsync(userManager, roleManager).GetAwaiter().GetResult();
            UserInitializer.SeedUsersAsync(userManager, roleManager).GetAwaiter().GetResult();
        }
    }
}
