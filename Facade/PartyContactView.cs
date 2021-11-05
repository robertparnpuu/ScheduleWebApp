using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class PartyContactView : BaseView
    {
        [Required]
        [Display(Name = "PartyID")]
        public string partyId { get; set; }
        [Required]
        [Display(Name = "ContactId")]
        public string contactId { get; set; }
        [Required]
        [Display(Name = "AddressId")]
        public string addressId { get; set; }
    }
}

