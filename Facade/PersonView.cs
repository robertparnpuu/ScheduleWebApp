using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class PersonView:BaseView
    {
        [Display(Name = "PartyContactId")]
        public string partyContactId { get; set; }
        public string contactId { get; set; }
        public string addressId { get; set; }
        public string partyId { get; set; }
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

        [Display(Name = "Address")]
        public string fullAddress { get; set; }
        [Display(Name = "Contacts")]
        public string fullContact { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Phone nr")]
        public string phoneNumber { get; set; }

        [Display(Name = "Apartment Nr")]
        public string apartmentNumber { get; set; }
        [Required]
        [Display(Name = "Street name")]
        public string streetName { get; set; }
        [Required]
        [Display(Name = "House Nr")]
        public string houseNumber { get; set; }
        [Required]
        [Display(Name = "City")]
        public string city { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public string zipCode { get; set; }
        [Required]
        [Display(Name = "Region")]
        public string region { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string country { get; set; }
    }
}
