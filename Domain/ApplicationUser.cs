using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

namespace Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonId { get; set; }
        protected Person person { get; set; }

    }
}
//public class ApplicationRoleManager : Microsoft.AspNetCore.Identity.RoleManager<MediaTypeNames.Application>
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
//    private RoleManager<IdentityRole> _roleManager;

//    public ApplicationUserManager(IUserStore<ApplicationUser> store)
//        : base(store)
//    {
//        _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
//    }

//    public async Task<IList<IdentityRole>> GetModelRolesAsync(string userId)
//    {
//        IList<string> roleNames = await base.GetRolesAsync(userId.ToString());

//        var identityRoles = new List<IdentityRole>();
//        foreach (var roleName in roleNames)
//        {
//            IdentityRole role = await _roleManager.FindByNameAsync(roleName);
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