using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class AddressData : BaseEntityData
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
