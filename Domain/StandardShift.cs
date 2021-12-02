using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class StandardShift : BaseEntity<StandardShiftData>
    {
        public StandardShift() : this(null) { }

        public StandardShift(StandardShiftData d) : base(d)
        {
            lazyReadLocation = GetLazy<Location, ILocationRepo>(x => x?.GetEntity(locationId));
            lazyReadOccupation = GetLazy<Occupation, IOccupationRepo>(x => x?.GetEntity(occupationId));
        }

        public string name => Data?.name ?? "-";
        public DateTime startTime => Data.startTime;
        public DateTime endTime => Data.endTime;

        public string locationId => Data?.locationId ?? "-";
        public Location shiftLocation => lazyReadLocation.Value;
        internal Lazy<Location> lazyReadLocation { get; }

        public string occupationId => Data?.occupationId ?? "-";
        public Occupation shiftOccupation => lazyReadOccupation.Value;
        internal Lazy<Occupation> lazyReadOccupation { get; }

    }
}