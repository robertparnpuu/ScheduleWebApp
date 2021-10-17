using System.ComponentModel.DataAnnotations;
using Facade.Common;
using Microsoft.VisualBasic;

namespace Facade
{
    public class DepartmentView: BaseView
    {
        [Display(Name = "Department name")]
        public string name { get; set; }
        public string contactId { get; set; }
        [Display(Name = "E-mail")]
        public string departmentEmail { get; set; }
        [Display(Name = "Phone number")]
        public string departmentPhoneNr { get; set; }

    }
}
