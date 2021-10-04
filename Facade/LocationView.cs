using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    class LocationView:BaseView
    {
        [Required]
        [Display(Name = "Asukoha nimetus")]
        public string name { get; set; }

        public string contactId { get; set; }
    }
}
