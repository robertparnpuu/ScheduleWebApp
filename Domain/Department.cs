using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Department : BaseEntity<DepartmentData>
    {
        public Department() : this(null) { }

        public Department(DepartmentData d) : base(d)
        {
            lazyReadPartyContact = GetLazy<PartyContact, IPartyContactRepo>(x => x?.GetEntity(partyContactId));
        }

        public string name => Data?.name ?? "-";
        public string fullAddress => departmentPartyContact?.fullAddress ?? "-";
        public string fullContact => departmentPartyContact?.fullContact ?? "-";

        public string partyContactId => Data?.partyContactId ?? "-";
        public PartyContact departmentPartyContact => lazyReadPartyContact.Value;
        internal Lazy<PartyContact> lazyReadPartyContact { get; }

    }
}