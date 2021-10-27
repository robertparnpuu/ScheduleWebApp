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

        [Display(Name = "Address")]
        public string fullAddress { get; set; }
        
    }
}
