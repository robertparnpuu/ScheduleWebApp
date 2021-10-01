using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain.Common;

namespace Domain
{
    public class Requirement : BaseEntity<RequirementData>
    {
        public Requirement() : this(null) { }
        public Requirement(RequirementData d) : base(d) { }

        public string locationId => Data?.locationId ?? "-";
        public Location requiredLocation => lazyReadLocation.Value;
        internal Lazy<Location> lazyReadLocation { get; }

        public string occupationId => Data?.occupationId ?? "-";
        public Occupation requiredOccupation => lazyReadOccupation.Value;
        internal Lazy<Occupation> lazyReadOccupation { get; }

        public int? minEmployees => Data?.minEmployees;
        public int? maxEmployees => Data?.maxEmployees;

        public DateTime? startTimeClock => Data?.startTime;
        public DateTime? endTimeClock => Data?.endTime;

        //TODO: oleks vajalik, et saaks valida mitmed päevad ühele nõudele
        public string weekdayId => Data.weekDayId;
        // public List<WeekDay> weekDays; 
    }
}