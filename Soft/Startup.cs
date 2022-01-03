using Domain.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infra;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Soft
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddRazorPages();
            AddServices(services);
            services.AddLogging();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        public void AddServices(IServiceCollection services)
        {
            services.AddTransient<IOccupationRepo, OccupationRepo>();
            services.AddTransient<IAddressRepo, AddressRepo>();
            services.AddTransient<IContactRepo, ContactRepo>();
            services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            services.AddTransient<ILocationRepo, LocationRepo>();
            services.AddTransient<IContractRepo, ContractRepo>();
            services.AddTransient<IPartyContactRepo, PartyContactRepo>();
            services.AddTransient<IPersonRepo, PersonRepo>();
            services.AddTransient<IRequirementRepo, RequirementRepo>();
            services.AddTransient<IShiftAssignmentRepo, ShiftAssignmentRepo>();
            services.AddTransient<IStandardShiftRepo, StandardShiftRepo>();
            services.AddTransient<IWeekDayRepo, WeekDayRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
