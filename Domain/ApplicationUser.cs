using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
    }
}
//public class ApplicationRoleManager : RoleManager<Application>
//{
//    public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
//        : base(roleStore)
//    {
//    }

//    public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
//    {
//        ///It is based on the same context as the ApplicationUserManager
//        var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<AppUsersDbContext>()));

//        return appRoleManager;
//    }
//public class ApplicationRole : IdentityRole
//{
//    public ApplicationRole() : base()
//    {
//    }
//}
//public class ApplicationUserManager : UserManager<ApplicationUser>
//{
//    private RoleManager<ApplicationRole> _roleManager;

//    public ApplicationUserManager(IUserStore<ApplicationUser> store)
//        : base(store)
//    {
//        _roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>());
//    }

//    public async Task<IList<ApplicationRole>> GetModelRolesAsync(string userId)
//    {
//        IList<string> roleNames = await base.GetRolesAsync(userId.ToString());

//        var identityRoles = new List<ApplicationRole>();
//        foreach (var roleName in roleNames)
//        {
//            ApplicationRole role = await _roleManager.FindByNameAsync(roleName);
//            identityRoles.Add(role);
//        }

//        return identityRoles;
//    }
//}
//public class UserRole : IdentityUserRole<string> {
//    public UserRole() : base()
//    {
//    }
//}
//public class UserClaim : IdentityUserClaim<string> {
//    public UserClaim() : base()
//    {

//    }
//}
//public class UserLogin : IdentityUserLogin<string> {
//    public UserLogin() : base()
//    {

//    }
//}