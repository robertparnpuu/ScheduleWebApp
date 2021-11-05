using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class PartyContactView : BaseView
    {
        [Required]
        [Display(Name = "PersonID")]
        public string personId { get; set; }
        [Required]
        [Display(Name = "Phone Nr")]
        public string contactId { get; set; }

    }
}

