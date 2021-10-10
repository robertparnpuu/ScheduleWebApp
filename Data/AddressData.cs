using Data.Common;

namespace Data
{
    public class AddressData : BaseEntityData
    {
        public string apartmentNumber { get; set;  }
        public string streetName { get; set;  }
        public string houseNumber {  get; set; }
        public string city {  get; set; }
        public string zipCode { get; set; }
        public string region { get; set;  }
        public string country {  get; set; }
    }
}
