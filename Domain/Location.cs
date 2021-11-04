using System;
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
        }
        public string name => Data?.name ?? "-";

        public string partyContactId => Data?.partyContactId ?? "-";
        public PartyContact locationPartyContact => lazyReadPartyContact.Value;
        internal Lazy<PartyContact> lazyReadPartyContact { get; }
    }
}