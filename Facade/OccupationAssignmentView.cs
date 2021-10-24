using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class OccupationAssignmentView : BaseView
    {
        [Required]
        [Display(Name = "Worker")]
        public string workerId { get; set; }
        
        [Required]
        [Display(Name = "Occupation")]
        public string occupationId { get; set; }

    
        [Display(Name = "Worker")]
        public string workerName { get; set; }

     
        [Display(Name = "Occupation")]
        public string occupationName { get; set; }

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
