using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class AddressDataTests:IdBaseTest<AddressData,BaseEntityData>
    {
       
        [TestMethod]
        public void ApartmentNumberTest() => IsProperty<string>(nameof(obj.apartmentNumber));
        [TestMethod]
        public void StreetNameTest() => IsProperty<string>(nameof(obj.streetName));
        [TestMethod]
        public void HouseNumberTest() => IsProperty<string>(nameof(obj.houseNumber));
        [TestMethod]
        public void CityTest() => IsProperty<string>(nameof(obj.city));
        [TestMethod]
        public void ZIpCodeTest() => IsProperty<string>(nameof(obj.zipCode));
        [TestMethod]
        public void RegionTest() => IsProperty<string>(nameof(obj.region));
        [TestMethod]
        public void CountryTest() => IsProperty<string>(nameof(obj.country));
    }
}
