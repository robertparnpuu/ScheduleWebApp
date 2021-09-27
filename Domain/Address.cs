using System;
using Data;
using Domain.Common;

namespace Domain
{
    public class Address : BaseEntity<AddressData>
    {
        public string Country
        {
            get => default;
            set
            {
                //TODO test
            }
        }

        public string City
        {
            get => default;
            set
            {
            }
        }

        public string StreetName
        {
            get => default;
            set
            {
            }
        }

        public String HouseNumber
        {
            get => default;
            set
            {
            }
        }

        public string AppartmentNumber
        {
            get => default;
            set
            {
            }
        }
    }
}