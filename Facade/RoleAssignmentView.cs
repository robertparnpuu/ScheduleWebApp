using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class RoleAssignmentView : BaseView
    {
        [Required]
        public string personId { get; set; }
        [Required]
        public string roleId { get; set; }


        [Required]
        [Display(Name = "Person name")]
        public string personName { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string roleName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Valid from")]
        public DateTime validFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Valid to")]
        public DateTime validTo { get; set; }
    }
}
