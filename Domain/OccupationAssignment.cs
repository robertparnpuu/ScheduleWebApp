using System;
using Data;
using Domain.Common;

namespace Domain
{
    public class OccupationAssignment : BaseEntity<OccupationAssignmentData>
    {
        public OccupationAssignment() : this(null) { }
        public OccupationAssignment(OccupationAssignmentData d) : base(d) { }

        public string occupationId => Data.occupationId;
        public Occupation occupation => lazyReadOccupation.Value;
        internal Lazy<Occupation> lazyReadOccupation { get; }

        public string workerId => Data.workerId;
        public Worker worker => lazyReadWorker.Value;
        internal Lazy<Worker> lazyReadWorker { get; }

        public DateTime validFrom => Data.validFrom;
        public DateTime validTo => Data.validTo;



    }
}