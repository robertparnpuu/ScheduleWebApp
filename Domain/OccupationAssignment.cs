using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class OccupationAssignment : BaseEntity<OccupationAssignmentData>
    {
        public OccupationAssignment() : this(null) { }

        public OccupationAssignment(OccupationAssignmentData d) : base(d)
        {
            lazyReadPerson = GetLazy<Person, IPersonRepo>(x => x?.GetEntity(personId));
            lazyReadOccupation = GetLazy<Occupation, IOccupationRepo>(x => x?.GetEntity(occupationId));
            lazyReadDepartment = GetLazy<Department, IDepartmentRepo>(x => x?.GetEntity(departmentId));
        }

        public string occupationId => Data?.occupationId ?? "-";
        public Occupation occupation => lazyReadOccupation.Value;
        internal Lazy<Occupation> lazyReadOccupation { get; }

        public string personId => Data.personId ?? "-";
        public Person person => lazyReadPerson.Value;
        internal Lazy<Person> lazyReadPerson { get; }

        public string departmentId => Data?.departmentId ?? "-";
        public Department department => lazyReadDepartment.Value;
        internal Lazy<Department> lazyReadDepartment { get; }

        public DateTime validFrom => Data.validFrom;
        public DateTime validTo => Data.validTo;


    }
}