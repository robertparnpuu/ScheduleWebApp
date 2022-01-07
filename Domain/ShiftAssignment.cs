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
            lazyReadContract = GetLazy<Contract, IContractRepo>(x => x?.GetEntity(contractId));
        }
        public string contractId => Data?.contractId ?? "-";
        public Contract shiftAssignmentContract => lazyReadContract.Value;
        internal Lazy<Contract> lazyReadContract { get; }

        public DateTime startTime => Data.startTime;
        public DateTime endTime => Data.endTime;

        public string locationId => Data?.locationId ?? "-";
        public Location shiftAssignmentLocation => lazyReadLocation.Value;
        internal Lazy<Location> lazyReadLocation { get; }
    }
}