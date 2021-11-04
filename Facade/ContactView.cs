using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class ContactView: BaseView
    {
        [Required]
        [Display(Name = "E-mail")]
        public string contactValue { get; set; }

        [Required]
        [Display(Name = "Phone nr")]
        public string contactTypeId { get; set; }

        [Required]
        [Display(Name = "Address")]  
        public string addressId { get; set; }
    }
}
