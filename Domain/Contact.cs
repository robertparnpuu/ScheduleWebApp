using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Contact : BaseEntity<ContactData>
    {
        public Contact() : this(null) { }

        public Contact(ContactData d) : base(d)
        {
            lazyReadAddress = GetLazy<Address, IAddressRepo>(x => x?.GetEntity(addressId));
            lazyReadContactType= GetLazy<ContactType, IContactTypeRepo>(x => x?.GetEntity(contactTypeId));
        }

        public string contactValue => Data?.contactValue ?? "-";

        public string contactTypeId => Data?.contactTypeId ?? "-";
        public ContactType contactContactType => lazyReadContactType.Value;
        internal Lazy<ContactType> lazyReadContactType { get; }

        public string addressId => Data?.addressId ?? "-";
        public Address contactAddress => lazyReadAddress.Value;
        internal Lazy<Address> lazyReadAddress { get; }
    }
}