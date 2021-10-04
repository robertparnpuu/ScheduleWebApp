using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class DepartmentView: BaseView
    {
        [Display(Name = "Osakonna nimetus")]
        public string name { get; set; }
        public string contactId { get; set; }

    }
}
