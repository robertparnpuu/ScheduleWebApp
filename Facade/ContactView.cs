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
        [Display(Name = "Telefoni nr")]
        public string phoneNumber { get; set; }

        [Display(Name = "Korteri number")]
        public string apartmentNumber { get; set; }

        [Required]
        [Display(Name = "Tänav")]
        public string streetName { get; set; }

        [Required]
        [Display(Name = "Maja number")]
        public string houseNumber { get; set; }

        [Required]
        [Display(Name = "Linn/asula")]
        public string city { get; set; }

        [Required]
        [Display(Name = "Sihtnumber")]
        public string zipCode { get; set; }

        [Required]
        [Display(Name = "Maakond")]
        public string region { get; set; }

        [Required]
        [Display(Name = "Riik")]
        public string country { get; set; }
    }
}
