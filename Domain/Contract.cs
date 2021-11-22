using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Contract : BaseEntity<ContractData>
    {
        public Contract() : this(null) { }

        public Contract(ContractData d) : base(d)
        {
            lazyReadPerson = GetLazy<Person, IPersonRepo>(x => x?.GetEntity(personId));
            lazyReadOccupation = GetLazy<Occupation, IOccupationRepo>(x => x?.GetEntity(occupationId));
            lazyReadDepartment = GetLazy<Department, IDepartmentRepo>(x => x?.GetEntity(departmentId));
        }

        public string occupationId => Data?.occupationId ?? "-";
        public Occupation contractOccupation => lazyReadOccupation.Value;
        internal Lazy<Occupation> lazyReadOccupation { get; }

        public string personId => Data.personId ?? "-";
        public string personName => contractPerson.fullName ?? "-"; //Required for selectlists
        public Person contractPerson => lazyReadPerson.Value;
        internal Lazy<Person> lazyReadPerson { get; }

        public string departmentId => Data?.departmentId ?? "-";
        public Department contractDepartment => lazyReadDepartment.Value;
        internal Lazy<Department> lazyReadDepartment { get; }

        public DateTime validFrom => Data?.validFrom ?? DateTime.MinValue;
        public DateTime validTo => Data?.validTo?? DateTime.MinValue;


    }
}