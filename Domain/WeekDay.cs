using Data;
using Domain.Common;

namespace Domain
{
    public class WeekDay : BaseEntity<WeekDayData>
    {
        public WeekDay() : this(null) { }
        public WeekDay(WeekDayData d) : base(d) { }

        public string name => Data?.name ?? "-";
    }
}