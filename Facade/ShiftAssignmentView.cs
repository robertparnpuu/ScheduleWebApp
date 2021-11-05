using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class ShiftAssignmentView:BaseView
    {
        [Required]
        [Display(Name = "Person")]
        public string personId { get; set; }
        [Required]
        [Display(Name = "Location name")]
        public string locationId { get; set; }

        [Display(Name = "Person name")]
        public string personName { get; set; }

        [Display(Name = "Location")]
        public string locationName { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Shift start time")]
        public DateTime startTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Shift end time")]
        public DateTime endTime { get; set; }

    }
}
