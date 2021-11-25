using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class ShiftAssignmentView:BaseView
    {
        [Required]
        [Display(Name = "Contract Id")]
        public string contractId { get; set; }
        [Display(Name = "Person")]
        public string personName { get; set; }

        //[Required]
        [Display(Name = "Location Id")]
        public string locationId { get; set; }

        [Display(Name = "Location")]
        public string locationName { get; set; }

        [Display(Name = "Occupation Id")]
        public string occupationId { get; set; }
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
