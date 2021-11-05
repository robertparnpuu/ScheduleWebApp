using System.ComponentModel.DataAnnotations;
using Facade.Common;
using Microsoft.VisualBasic;

namespace Facade
{
    public class DepartmentView: BaseView
    {
        [Display(Name = "Department name")]
        public string name { get; set; }
        [Display(Name = "PartyContactId")]
        public string partyContactId { get; set; }

    }
}
