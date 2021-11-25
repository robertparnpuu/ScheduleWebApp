using System;
using Data.Common;
using Domain.Repos;

namespace Domain.Common
{
    public abstract class WithContact<TData> : BaseEntity<TData>
    where TData : WithContactData, new()
    {
        protected WithContact(TData d):base (d)
        {
            lazyReadPartyContact = GetLazy<PartyContact, IPartyContactRepo>(x => x?.GetEntity(partyContactId));
        }

        public string partyContactId => Data?.partyContactId ?? "-";
        public PartyContact partyContact => lazyReadPartyContact.Value;
        internal Lazy<PartyContact> lazyReadPartyContact { get; }

        public string contactId => partyContact?.contactId ?? "-";
        public string addressId => partyContact?.addressId ?? "-";        
        public string partyId => partyContact?.partyId ?? "-";

        public string email => partyContact?.partyContactContact.email ?? "-";
        public string phoneNumber => partyContact?.partyContactContact.phoneNumber ?? "-";

        public string apartmentNumber => partyContact?.partyContactAddress.apartmentNumber ?? "-";
        public string streetName => partyContact?.partyContactAddress.streetName ?? "-";
        public string houseNumber => partyContact?.partyContactAddress.houseNumber ?? "-";
        public string city => partyContact?.partyContactAddress.city ?? "-";
        public string zipCode => partyContact?.partyContactAddress.zipCode ?? "-";
        public string region => partyContact?.partyContactAddress.region ?? "-";
        public string country => partyContact?.partyContactAddress.country ?? "-";
    }
}