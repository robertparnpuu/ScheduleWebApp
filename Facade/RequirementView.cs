using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class RequirementView: BaseView
    {
        [Required]
        [Display(Name = "Location")]
        public string locationId { get; set; }
        public string locationName { get; set; }

        [Required]
        [Display(Name = "Occupation")]
        public string occupationId { get; set; }
        public string occupationName { get; set; }

        [Display(Name = "Weekday")]
        public string weekDayId { get; set; }
        public string weekDayName { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Start time")]
        public DateTime startTime { get; set; }
        
        [DataType(DataType.Time)]
        [Display(Name = "End time")]
        public DateTime endTime { get; set; }

        [Display(Name = "Min nr of workers")]
        public int minEmployees { get; set; }

        [Display(Name = "Max nr of workers")]
        public int maxEmployees { get; set; }
    }
}
