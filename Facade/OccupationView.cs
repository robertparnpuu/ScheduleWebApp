using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class OccupationView: BaseView
    {
        [Required]
        [Display(Name = "Occupation")]
        public string name { get; set; }

        //TODO: töötajate list
    }
}
