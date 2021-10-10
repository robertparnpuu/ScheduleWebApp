using System;
using Data;
using Domain.Common;

namespace Domain
{
    public class Worker : BaseEntity<WorkerData>
    {
        public Worker() : this(null) { }
        public Worker(WorkerData d) : base(d) { }

        public string personId => Data?.personId ?? "-";
        public Person person => lazyReadPerson.Value;
        internal Lazy<Person> lazyReadPerson { get; }

        public string departmentId => Data?.departmentId ?? "-";
        public Department workerDepartment => lazyReadDepartment.Value;
        internal Lazy<Department> lazyReadDepartment { get; }
    }
}