using System;
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
            lazyReadPerson = GetLazy<Person, IPersonRepo>(x => x?.GetEntity(personId));
        }

        //public string firstName => Data?.firstName ?? "-";
        //public string lastName => Data?.lastName ?? "-";
        public string personId => Data?.personId ?? "-";
        public Person person => lazyReadPerson.Value;
        internal Lazy<Person> lazyReadPerson { get; }

        //public ICollection<ShiftAssignment> ShiftAssignments => shiftAssignments.Value;
        //internal Lazy<ICollection<ShiftAssignment>> shiftAssignments { get; }

        public string departmentId => Data?.departmentId ?? "-";
        public Department workerDepartment => lazyReadDepartment.Value;
        internal Lazy<Department> lazyReadDepartment { get; }

        public string fullName => person.fullName;
    }
}