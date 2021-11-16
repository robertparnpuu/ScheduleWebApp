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
        public DateTime? dateOfBirth => Data?.dateOfBirth ?? DateTime.MinValue;
        public string idCode => Data?.idCode ?? "-";
        public string roleAssignmentId => Data?.roleAssignmentId ?? "-";

        public string fullName => $"{firstName} {lastName}";
        public string fullAddress=> personPartyContact?.fullAddress ?? "-";
        public string fullContact => personPartyContact?.fullContact ?? "-";

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