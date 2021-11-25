using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade.Common
{
    public abstract class WithContactView:BaseView
    {
        [Display(Name = "PartyContactId")]
        public string partyContactId { get; set; }
        public string contactId { get; set; }
        public string addressId { get; set; }
        public string partyId { get; set; }

        [Display(Name = "Address")]
        public string fullAddress { get; set; }

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
