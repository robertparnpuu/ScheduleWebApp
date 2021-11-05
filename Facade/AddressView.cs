

using Facade.Common;
using System.ComponentModel.DataAnnotations;

namespace Facade
{
    public class AddressView:BaseView
    {
        [Required]
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
