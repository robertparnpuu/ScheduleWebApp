using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class RoleAssignmentView : BaseView
    {
        [Required]
        public string workerId { get; set; }
        [Required]
        public string roleId { get; set; }


        [Required]
        [Display(Name = "Töötaja nimi")]
        public string workerName { get; set; }

        [Required]
        [Display(Name = "Roll")]
        public string roleName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Kehtiv alates")]
        public DateTime validFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Kehtiv kuni")]
        public DateTime validTo { get; set; }
    }
}
