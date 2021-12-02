using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class DepartmentView: WithContactView
    {
        [Display(Name = "Department name")]
        public string name { get; set; }
        [Display(Name = "Address")]
        public string fullAddress { get; set; }
        [Display(Name = "Contacts")]
        public string fullContact { get; set; }
    }
}
