using System;
using System.Collections.Generic;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Person : BaseEntity<PersonData>
    {
        public Person() : this(null) { }

        public Person(PersonData d) : base(d)
        {
            lazyReadContacts= new Lazy<ICollection<Contact>>(GetPersonContacts());
        }
        public string firstName => Data?.firstName ?? "-";
        public string lastName => Data?.lastName ?? "-";
        public DateTime? dateOfBirth => Data?.dateOfBirth;
        public string idCode => Data?.idCode ?? "-";
        public string roleAssignmentId => Data?.roleAssignmentId ?? "-";
        public string fullName => $"{firstName} {lastName}";
      
        public ICollection<Contact> personContacts => lazyReadContacts.Value;
        internal Lazy<ICollection<Contact>> lazyReadContacts { get; }
        internal ICollection<Contact> GetPersonContacts()
            => new GetRepo().Instance<IContactRepo>()?.GetByPersonId(id);
    }
}