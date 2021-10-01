using System;
using Data;
using Domain.Common;

namespace Domain
{
    public class Department : BaseEntity<DepartmentData>
    {
        public Department() : this(null) { }
        public Department(DepartmentData d) : base(d) { }

        public string name => Data.name;

        public string contactId => Data?.contactId ?? "-";
        public Contact departmentContact => lazyReadContact.Value;
        internal Lazy<Contact> lazyReadContact { get; }

        //TODO: LIST
        //public List<Worker> workers;
    }
}