using System;
using Data;
using Domain.Common;

namespace Domain
{
    public class Person : BaseEntity<PersonData>
    {
        public Person() : this(null) { }
        public Person(PersonData d) : base(d) { }
        public string firstName => Data?.firstName ?? "-";
        public string lastName => Data?.lastName ?? "-";

        public DateTime? dateOfBirth => Data?.dateOfBirth;

        public string idCode => Data?.idCode ?? "-";
        public string contactId => Data?.contactId ?? "-";
        public Contact contact => lazyReadContact.Value;
        internal Lazy<Contact> lazyReadContact { get; }
    }
}