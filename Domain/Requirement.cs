using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Requirement : BaseEntity<RequirementData>
    {
        public Requirement() : this(null) { }

        public Requirement(RequirementData d) : base(d)
        {
            lazyReadLocation = GetLazy<Location, ILocationRepo>(x => x?.GetEntity(locationId));
            lazyReadOccupation = GetLazy<Occupation, IOccupationRepo>(x => x?.GetEntity(occupationId));
            lazyReadWeekDay = GetLazy<WeekDay, IWeekDayRepo>(x => x?.GetEntity(weekDayId));
        }

        public string locationId => Data?.locationId ?? "-";
        public Location requirementLocation => lazyReadLocation.Value;
        internal Lazy<Location> lazyReadLocation { get; }

        public string occupationId => Data?.occupationId ?? "-";
        public Occupation requirementOccupation => lazyReadOccupation.Value;
        internal Lazy<Occupation> lazyReadOccupation { get; }

        public int? minEmployees => Data?.minEmployees;
        public int? maxEmployees => Data?.maxEmployees;

        public DateTime? startTime => Data?.startTime ?? DateTime.MinValue;
        public DateTime? endTime => Data?.endTime ?? DateTime.MinValue;

        public string weekDayId => Data?.weekDayId ?? "-";
        public WeekDay requirementWeekDay => lazyReadWeekDay.Value;
        internal Lazy<WeekDay> lazyReadWeekDay { get; }


    }
}