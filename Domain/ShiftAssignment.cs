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
            //lazyReadPerson = GetLazy<Person, IPersonRepo>(x => x?.GetEntity(personId));
            lazyReadContract = GetLazy<Contract, IContractRepo>(x => x?.GetEntity(contractId));
        }
        //TODO 17.person muutub contractiks(ENTITY; DATA JMS VEEL VAJA )
        //public string personId => Data?.personId ?? "-";
        public string contractId => Data?.contractId ?? "-";
        //public Person shiftAssignmentPerson => lazyReadPerson.Value;
        public Contract shiftAssignmentContract => lazyReadContract.Value;
        //internal Lazy<Person> lazyReadPerson { get; }
        internal Lazy<Contract> lazyReadContract { get; }

        public DateTime startTime => Data.startTime;
        public DateTime endTime => Data.endTime;

        public string locationId => Data?.locationId ?? "-";
        public Location shiftAssignmentLocation => lazyReadLocation.Value;
        internal Lazy<Location> lazyReadLocation { get; }
    }
}