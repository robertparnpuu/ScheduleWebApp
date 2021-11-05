using Data;
using Domain.Common;

namespace Domain
{
    public class Address : BaseEntity<AddressData>
    {
        public Address() : this(null) { }
        public Address(AddressData d) : base(d) { }

        public string apartmentNumber => Data?.apartmentNumber ?? "-";
        public string streetName => Data?.streetName ?? "-";
        public string houseNumber => Data?.houseNumber ?? "-";
        public string city => Data?.city ?? "-";
        public string zipCode => Data?.zipCode ?? "-";
        public string region => Data?.region ?? "-";
        public string country => Data?.country ?? "-";
        public string partyContactId => Data?.partyContactId ?? "-";
    }
}
