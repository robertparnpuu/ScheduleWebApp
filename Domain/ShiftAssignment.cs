using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class ShiftAssignment : BaseEntity<ShiftAssignmentData>
    {
        public ShiftAssignment() : this(null) { }

        public ShiftAssignment(ShiftAssignmentData d) : base(d)
        {
            lazyReadLocation= GetLazy<Location, ILocationRepo>(x => x?.GetEntity(locationId));
            lazyReadWorker = GetLazy<Worker, IWorkerRepo>(x => x?.GetEntity(workerId));
        }

        public string workerId => Data?.workerId ?? "-";
        public Worker worker => lazyReadWorker.Value;
        internal Lazy<Worker> lazyReadWorker { get; }

        public DateTime startTime => Data.startTime;
        public DateTime endTime => Data.endTime;

        public string locationId => Data?.locationId ?? "-";
        public Location location => lazyReadLocation.Value;
        internal Lazy<Location> lazyReadLocation { get; }
    }
}