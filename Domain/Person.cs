using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Person : WithContact<PersonData>
    {
        public Person() : this(null) { }

        public Person(PersonData d):base(d) { }

        public string firstName => Data?.firstName ?? "-";
        public string lastName => Data?.lastName ?? "-";
        public DateTime? dateOfBirth => Data?.dateOfBirth ?? DateTime.MinValue;
        public string idCode => Data?.idCode ?? "-";
        public string roleAssignmentId => Data?.roleAssignmentId ?? "-";

        public string fullName => $"{firstName} {lastName}";
        public string fullAddress=> partyContact?.fullAddress ?? "-";
        public string fullContact => partyContact?.fullContact ?? "-";

        //public string contactId => partyContact.contactId;
        //public string addressId => partyContact.addressId;

        //public string partyContactId => Data?.partyContactId ?? "-";
        //public PartyContact partyContact => lazyReadPartyContact.Value;
        //internal Lazy<PartyContact> lazyReadPartyContact { get; }
        //public string partyId => partyContact.partyId;


        //public string email => partyContact.partyContactContact.email;
        //public string phoneNumber => partyContact.partyContactContact.phoneNumber;


        //public string apartmentNumber => partyContact.partyContactAddress.apartmentNumber;
        //public string streetName => partyContact.partyContactAddress.streetName;
        //public string houseNumber => partyContact.partyContactAddress.houseNumber;
        //public string city => partyContact.partyContactAddress.city;
        //public string zipCode => partyContact.partyContactAddress.zipCode;
        //public string region => partyContact.partyContactAddress.region;
        //public string country => partyContact.partyContactAddress.country;
    }
}