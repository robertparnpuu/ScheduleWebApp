using Domain.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infra;

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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            AddServices(services);

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
            services.AddTransient<IRoleRepo, RoleRepo>();
            services.AddTransient<IRoleAssignmentRepo, RoleAssignmentRepo>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
