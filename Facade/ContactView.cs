using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class ContactView: BaseView
    {
        [Required]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Phone nr")]
        public string phoneNumber { get; set; }

        [Required]
        [Display(Name = "Address")]  
        public string addressId { get; set; }
        public string fullAddress { get; set; }
        

        //[Display(Name = "Apartment nr")]
        //public string apartmentNumber { get; set; }

        //[Required]
        //[Display(Name = "Street")]
        //public string streetName { get; set; }

        //[Required]
        //[Display(Name = "House number")]
        //public string houseNumber { get; set; }

        //[Required]
        //[Display(Name = "City")]
        //public string city { get; set; }

        //[Required]
        //[Display(Name = "Zipcode")]
        //public string zipCode { get; set; }

        //[Required]
        //[Display(Name = "Region")]
        //public string region { get; set; }

        //[Required]
        //[Display(Name = "Country")]
        //public string country { get; set; }
    }
}
