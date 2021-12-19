
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

public static class ContextSeed
{
    public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Roles
        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Manager.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Scheduler.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Viewer.ToString()));
    }
}