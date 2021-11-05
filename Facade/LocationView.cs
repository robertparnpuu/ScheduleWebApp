using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class LocationView:BaseView
    {
        [Required]
        [Display(Name = "Location name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "PartyContactId")]
        public string partyContactId { get; set; }
    }
}
