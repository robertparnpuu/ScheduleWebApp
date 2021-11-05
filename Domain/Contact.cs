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
        }

        public string email => Data?.email ?? "-";
        public string phoneNumber => Data?.phoneNumber ?? "-";
        public string fullContact => $"{email}, {phoneNumber}" ?? "-";

        public string addressId => Data?.addressId ?? "-";
        public Address contactAddress => lazyReadAddress.Value;
        internal Lazy<Address> lazyReadAddress { get; }
    }
}