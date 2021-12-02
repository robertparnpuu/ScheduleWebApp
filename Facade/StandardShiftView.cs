using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class StandardShiftView: BaseView
    {
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Shift start time")]
        public DateTime startTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Shift end time")]
        public DateTime endTime { get; set; }

        [Display(Name = "Occupation")]
        public string occupationId { get; set; }
        [Display(Name = "Occupation")]
        public string occupationName { get; set; }
        
        [Display(Name = "Location")]
        public string locationId { get; set; }
        [Display(Name = "Location")]
        public string locationName { get; set; }

       
    }
}
