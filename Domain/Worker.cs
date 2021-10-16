using System;
using System.Collections.Generic;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Worker : BaseEntity<WorkerData>
    {
        public Worker() : this(null) { }

        public Worker(WorkerData d) : base(d)
        {
            //shiftAssignments = GetLazy<ShiftAssignment, IShiftAssignmentRepo>(x => x?.GetById(id));
        }

        public string personId => Data?.personId ?? "-";
        public Person person => lazyReadPerson.Value;
        internal Lazy<Person> lazyReadPerson { get; }

        public string occupationAssignmentId => Data?.occupationAssignmentId ?? "-";
        public OccupationAssignment occupationAssignment => lazyReadOccupationAssignment.Value;
        internal Lazy<OccupationAssignment> lazyReadOccupationAssignment { get; }

        //public ICollection<ShiftAssignment> ShiftAssignments => shiftAssignments.Value;
        //internal Lazy<ICollection<ShiftAssignment>> shiftAssignments { get; }

        public string departmentId => Data?.departmentId ?? "-";
        public Department workerDepartment => lazyReadDepartment.Value;
        internal Lazy<Department> lazyReadDepartment { get; }
    }
}