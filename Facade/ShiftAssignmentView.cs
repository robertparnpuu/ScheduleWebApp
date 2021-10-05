using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class ShiftAssignmentView:BaseView
    {
        [Required]
        public string workerId { get; set; }
        [Required]
        public string locationId { get; set; }


        [Required]
        [Display(Name = "Workers name")]
        public string workerName { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string locationName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Shift start time")]
        public DateTime startTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Shift end time")]
        public DateTime endTime { get; set; }

    }
}
