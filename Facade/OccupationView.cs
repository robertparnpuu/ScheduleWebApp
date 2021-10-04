using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    class OccupationView: BaseView
    {
        [Required]
        [Display(Name = "Ametikoha nimetus")]
        public string name { get; set; }

        //TODO: töötajate list
    }
}
