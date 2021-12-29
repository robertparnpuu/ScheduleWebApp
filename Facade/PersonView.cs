 using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class PersonView:WithContactView
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name max length is 50 characters")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "First name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name max length is 50 characters")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Last name")]
        public string lastName { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "ID code must consist of 11 numbers")]
        [Display(Name = "ID code")]
        public string idCode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime dateOfBirth { get; set; }

        [Display(Name = "Full name")]
        public string fullName { get; set; }

        [Display(Name = "Username")]
        public string userName { get; set; }

    }
}
