using System;
using Data;
using Domain.Common;

namespace Domain
{
    public class Location : BaseEntity<LocationData>
    {
        public Location() : this(null) { }
        public Location(LocationData d) : base(d) { }
        public string name => Data?.name ?? ".";

        public string contactId => Data?.contactId ?? "-";
        public Contact contact => lazyReadContact.Value;
        internal Lazy<Contact> lazyReadContact { get; }
    }
}