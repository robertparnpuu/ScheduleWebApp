using System.ComponentModel.DataAnnotations;

namespace Facade
{
    public class UserView
    {
        [Required]
        [Display(Name = "Username")]
        public string userName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }

        [Required]
        [Display(Name = "Person")]
        public string userPersonId { get; set; }
    }
}
