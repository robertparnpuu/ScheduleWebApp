
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

public static class ContextSeed
{
    public static async Task SeedRolesAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Roles
        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Manager.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Scheduler.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Viewer.ToString()));
    }
}