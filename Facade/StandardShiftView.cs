using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class StandardShiftView: BaseView
    {
        [Required]
        public string occupationId { get; set; }
        [Required]
        public string locationId { get; set; }


        [Required]
        [Display(Name = "Occupation")]
        public string occupationName { get; set; }

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
