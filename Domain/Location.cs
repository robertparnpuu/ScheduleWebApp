using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Location : WithContact<LocationData>
    {
        public Location() : this(null) { }

        public Location(LocationData d) : base(d)
        { }
        public string name => Data?.name ?? "-";
        public string fullAddress => partyContact?.fullAddress ?? "-";
        public string fullContact => partyContact?.fullContact ?? "-";


        //public ICollection<Contact> locationContacts => lazyReadContacts.Value;
        //internal Lazy<ICollection<Contact>> lazyReadContacts { get; }
        //internal ICollection<Contact> GetLocationContacts()
        //    => new GetRepo().Instance<IContactRepo>()?.GetByLocationId(id);
    }
}