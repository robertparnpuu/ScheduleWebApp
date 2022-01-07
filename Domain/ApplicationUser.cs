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