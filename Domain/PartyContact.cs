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

        public string personId => Data?.personId ?? "-";

        public string contactId => Data?.contactId ?? "-";
        public Contact partyContactContact => lazyReadContact.Value;
        internal Lazy<Contact> lazyReadContact { get; }

        public string addressId => Data?.addressId ?? "-";
        public Address partyContactAddress => lazyReadAddress.Value;
        internal Lazy<Address> lazyReadAddress { get; }
    }
}