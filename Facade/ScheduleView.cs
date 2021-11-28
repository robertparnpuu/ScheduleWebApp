using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class ScheduleView:BaseView
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

        [Display(Name = "Occupation")]
        public string occupationName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Shift start time")]
        public DateTime startTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Shift end time")]
        public DateTime endTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime dateChoice { get; set; }
    }
}
