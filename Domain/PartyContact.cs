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
            lazyReadPerson = GetLazy<Person, IPersonRepo>(x => x?.GetEntity(personId));
            lazyReadContact = GetLazy<Contact, IContactRepo>(x => x?.GetEntity(contactId));
        }

        public string personId => Data?.personId ?? "-";
        public Person partyContactPerson => lazyReadPerson.Value;
        internal Lazy<Person> lazyReadPerson { get; }

        public string contactId => Data?.contactId ?? "-";
        public Contact partyContactContact => lazyReadContact.Value;
        internal Lazy<Contact> lazyReadContact { get; }
    }
}