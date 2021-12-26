using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Infra.Initializer
{
    public static class UserInitializer
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Manager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Scheduler.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Viewer.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
            UserName = "superadmin",
            Email = "superadmin@gmail.com",
            FirstName = "Super",
            LastName = "Admin",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Super1.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Manager.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Scheduler.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Viewer.ToString());
                }
            }
        }

        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
                var manager = new ApplicationUser
                {
                UserName = "manager",
                Email = "manager@gmail.com",
                FirstName = "manager",
                LastName = "manager",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
                };
                if (userManager.Users.All(u => u.Id != manager.Id))
                {
                    var user = await userManager.FindByEmailAsync(manager.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(manager, "Manager1.");
                        await userManager.AddToRoleAsync(manager, Enums.Roles.Manager.ToString());
                        await userManager.AddToRoleAsync(manager, Enums.Roles.Viewer.ToString());
                    }
                }
                var scheduler = new ApplicationUser
                {
                UserName = "scheduler",
                Email = "scheduler@gmail.com",
                FirstName = "scheduler",
                LastName = "scheduler",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
                };
                if (userManager.Users.All(u => u.Id != scheduler.Id))
                {
                    var user = await userManager.FindByEmailAsync(scheduler.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(scheduler, "Scheduler1.");
                        await userManager.AddToRoleAsync(scheduler, Enums.Roles.Scheduler.ToString());
                        await userManager.AddToRoleAsync(scheduler, Enums.Roles.Viewer.ToString());
                    }
                }
                var viewer = new ApplicationUser
                {
                UserName = "viewer",
                Email = "viewer@gmail.com",
                FirstName = "viewer",
                LastName = "viewer",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
                };
                if (userManager.Users.All(u => u.Id != viewer.Id))
                {
                    var user = await userManager.FindByEmailAsync(viewer.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(viewer, "Viewer1.");
                        await userManager.AddToRoleAsync(viewer, Enums.Roles.Viewer.ToString());
                    }
                }

        }
    }
}