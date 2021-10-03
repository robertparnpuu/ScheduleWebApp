using System;
using Data;
using Domain.Common;

namespace Domain
{
    public class Contact : BaseEntity<ContactData>
    {
        public Contact() : this(null) { }
        public Contact(ContactData d) : base(d) { }
        public string email => Data?.email ?? "-";

        public string phoneNumber => Data?.phoneNumber ?? "-";

        public string addressId => Data?.addressId ?? "-";
        public Address contactAddress => lazyReadAddress.Value;
        internal Lazy<Address> lazyReadAddress { get; }
    }
}