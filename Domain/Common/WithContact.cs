using System;
using Data.Common;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public abstract class WithContact<TData> : BaseEntity<TData>
    where TData : WithContactData, new()
    {
        protected WithContact(TData d):base (d)
        {
            lazyReadPartyContact = GetLazy<PartyContact, IPartyContactRepo>(x => x?.GetEntity(partyContactId));
        }

        public string contactId => personPartyContact.contactId;
        public string addressId => personPartyContact.addressId;
        public string partyContactId => Data?.partyContactId ?? "-";

        public PartyContact personPartyContact => lazyReadPartyContact.Value;
        internal Lazy<PartyContact> lazyReadPartyContact { get; }
        public string partyId => personPartyContact.partyId;


        public string email => personPartyContact.partyContactContact.email;
        public string phoneNumber => personPartyContact.partyContactContact.phoneNumber;


        public string apartmentNumber => personPartyContact.partyContactAddress.apartmentNumber;
        public string streetName => personPartyContact.partyContactAddress.streetName;
        public string houseNumber => personPartyContact.partyContactAddress.houseNumber;
        public string city => personPartyContact.partyContactAddress.city;
        public string zipCode => personPartyContact.partyContactAddress.zipCode;
        public string region => personPartyContact.partyContactAddress.region;
        public string country => personPartyContact.partyContactAddress.country;
    }
}