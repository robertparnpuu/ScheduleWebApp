using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Person : BaseEntity<PersonData>
    {
        public Person() : this(null)
        {
        }

        public Person(PersonData d) : base(d)
        {
            lazyReadPartyContact = GetLazy<PartyContact, IPartyContactRepo>(x => x?.GetEntity(partyContactId));
        }

        public string firstName => Data?.firstName ?? "-";
        public string lastName => Data?.lastName ?? "-";
        public DateTime? dateOfBirth => Data?.dateOfBirth;
        public string idCode => Data?.idCode ?? "-";
        public string roleAssignmentId => Data?.roleAssignmentId ?? "-";

        public string fullName => $"{firstName} {lastName}";

        public string partyContactId => Data?.partyContactId ?? "-";
        public PartyContact personPartyContact => lazyReadPartyContact.Value;
        internal Lazy<PartyContact> lazyReadPartyContact { get; }
    }
}