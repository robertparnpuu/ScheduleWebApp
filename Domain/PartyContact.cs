using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class PartyContact : BaseEntity<PartyContactData>
    {
        public PartyContact() : this(null)
        {
        }

        public PartyContact(PartyContactData d) : base(d)
        {
            lazyReadContact = GetLazy<Contact, IContactRepo>(x => x?.GetEntity(contactId));
            lazyReadAddress = GetLazy<Address, IAddressRepo>(x => x?.GetEntity(addressId));
        }

        public string contact => partyContactContact.contacts;
        public string fullAddress => partyContactAddress.fullAddress;

        public string contactId => Data?.contactId ?? "-";
        public Contact partyContactContact => lazyReadContact.Value;
        internal Lazy<Contact> lazyReadContact { get; }

        public string addressId => Data?.addressId ?? "-";
        public Address partyContactAddress => lazyReadAddress.Value;
        internal Lazy<Address> lazyReadAddress { get; }

        public string partyId => Data?.partyId ?? "-";
        public Address partyContactParty => lazyReadParty.Value;
        internal Lazy<Address> lazyReadParty { get; }

    }
}