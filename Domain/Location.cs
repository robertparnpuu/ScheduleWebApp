using System;
using System.Collections.Generic;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Location : BaseEntity<LocationData>
    {
        public Location() : this(null) { }

        public Location(LocationData d) : base(d)
        {
            lazyReadPartyContact = GetLazy<PartyContact, IPartyContactRepo>(x => x?.GetEntity(partyContactId));
            lazyReadContacts = new Lazy<ICollection<Contact>>(GetLocationContacts);
        }
        public string name => Data?.name ?? "-";

        public string partyContactId => Data?.partyContactId ?? "-";
        public PartyContact locationPartyContact => lazyReadPartyContact.Value;
        internal Lazy<PartyContact> lazyReadPartyContact { get; }

        public ICollection<Contact> locationContacts => lazyReadContacts.Value;
        internal Lazy<ICollection<Contact>> lazyReadContacts { get; }
        internal ICollection<Contact> GetLocationContacts()
            => new GetRepo().Instance<IContactRepo>()?.GetByLocationId(id);
    }
}