using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Domain;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class AddressEntityTests : BaseEntityTests<Address, AddressData>
    {
        [TestMethod]
        public void ApartmentNumberTest() => isReadOnlyProperty(obj.Data.apartmentNumber);
        [TestMethod]
        public void StreetNameTest() => isReadOnlyProperty(obj.Data.streetName);
        [TestMethod]
        public void HouseNumberTest() => isReadOnlyProperty(obj.Data.houseNumber);
        [TestMethod]
        public void CityTest() => isReadOnlyProperty(obj.Data.city);
        [TestMethod]
        public void ZipCodeTest() => isReadOnlyProperty(obj.Data.zipCode);
        [TestMethod]
        public void RegopmTest() => isReadOnlyProperty(obj.Data.region);
        [TestMethod]
        public void CountryTest() => isReadOnlyProperty(obj.Data.country);

    }
}

