using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int UsernameChangeLimit { get; set; } = 10;
}
public class UserRole : IdentityUserRole<string> { }
public class UserClaim : IdentityUserClaim<string> { }
public class UserLogin : IdentityUserLogin<string> { }