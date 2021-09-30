using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain.Common;

namespace Domain
{
    public class ShiftAssignment : BaseEntity<ShiftAssignmentData>
    {
        public ShiftAssignment() : this(null) { }
        public ShiftAssignment(ShiftAssignmentData d) : base(d) { }

        public string workerId => Data.workerId;
        public Worker worker => lazyReadWorker.Value;
        internal Lazy<Worker> lazyReadWorker { get; }

        public DateTime endTime => Data.endTime;
        public DateTime startTime => Data.startTime;

        public string locationId => Data.locationId;
        public Location location => lazyReadLocation.Value;
        internal Lazy<Location> lazyReadLocation { get; }
    }
}