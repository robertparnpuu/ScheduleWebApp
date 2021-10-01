using System;
using Data;
using Domain.Common;

namespace Domain
{
    public class Address : BaseEntity<AddressData>
    {
        public string apartmentNumber { get; set; }
        public string streetName { get; set; }
        public string houseNumber { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string region { get; set; }
        public string country { get; set; }
    }
}