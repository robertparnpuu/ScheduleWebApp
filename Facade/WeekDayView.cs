using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class WeekDayView: BaseView
    {
        [Required]
        [Display(Name = "Weekday")]
        public string name { get; set; }
    }
}
