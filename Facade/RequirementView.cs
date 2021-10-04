using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class RequirementView: BaseView
    {
        [Required]
        [Display(Name = "Asukoht")]
        public string locationId { get; set; }

        [Required]
        [Display(Name = "Ametikoht")]
        public string occupationId { get; set; }

        [Display(Name = "Nädalapäev")]
        public string weekDayId { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Name = "Tööaja algusaeg")]
        public DateTime startTime { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Tööaja lõpuaeg")]
        public DateTime endTime { get; set; }

        [Display(Name = "Minimaalne töötajate arv")]
        public int minEmployees { get; set; }

        [Display(Name = "Maksimaalne töötajate arv")]
        public int maxEmployees { get; set; }
    }
}
