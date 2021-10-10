using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class RoleView :BaseView
    {
        [Required]
        [Display(Name = "Role")]
        public string name { get; set; }
    }
}
