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
            lazyReadContact = GetLazy<Contact, IContactRepo>(x => x?.GetEntity(contactId));
        }
        public string name => Data?.name ?? "-";

        public string contactId => Data?.contactId ?? "-";
        public Contact locationContact => lazyReadContact.Value;
        internal Lazy<Contact> lazyReadContact { get; }
    }
}