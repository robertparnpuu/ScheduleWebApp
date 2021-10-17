using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class PersonView : BaseView
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name max length is 50 characters")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "First name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2,ErrorMessage = "Last name max length is 50 characters")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Last name")]
        public string lastName { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "ID code must consist of 11 numbers")]
        [Display(Name = "ID code")]
        public string idCode { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime dateOfBirth { get; set; }

        public string contactId { get; set; }

        [Display(Name = "E-mail")]
        public string personEmail { get; set; }

        [Display(Name = "Phone nr")]
        public string personPhoneNr { get; set; }
    }
}
