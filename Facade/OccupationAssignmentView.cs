using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class OccupationAssignmentView : BaseView
    {
        [Required]
        [Display(Name = "Person")]
        public string personId { get; set; }
        
        [Required]
        [Display(Name = "Occupation")]
        public string occupationId { get; set; }
        
        [Required]
        [Display(Name = "Department")]
        public string departmentId { get; set; }


        [Display(Name = "Person")]
        public string personName { get; set; }

        [Display(Name = "Occupation")]
        public string occupationName { get; set; }

        [Display(Name = "Department")]
        public string departmentName { get; set; }


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
