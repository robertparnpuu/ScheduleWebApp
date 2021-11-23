using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int UsernameChangeLimit { get; set; } = 10;
    public ApplicationUser() : base()
    {
    }
}
public class ApplicationRole : IdentityRole
{
    public ApplicationRole() : base()
    {
    }
}
public class UserRole : IdentityUserRole<string> {
    public UserRole() : base()
    {
    }
}
public class UserClaim : IdentityUserClaim<string> {
    public UserClaim() : base()
    {

    }
}
public class UserLogin : IdentityUserLogin<string> {
    public UserLogin() : base()
    {

    }
}