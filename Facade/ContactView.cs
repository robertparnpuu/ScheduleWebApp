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
        [Display(Name = "Phone Nr")]
        public string phoneNumber { get; set; }

        [Required]
        [Display(Name = "PartyContactId")]  
        public string partyContactId { get; set; }
    }
}
