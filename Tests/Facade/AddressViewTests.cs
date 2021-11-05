using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class AddressViewTests : BaseViewTests<AddressView>
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
        public void ZipCodeTest() => IsProperty<string>(nameof(obj.zipCode));
        [TestMethod]
        public void RegionTest() => IsProperty<string>(nameof(obj.region));

        [TestMethod]
        public void CountryTest() => IsProperty<string>(nameof(obj.country));
        [TestMethod]
        public void partyContactIdTest() => IsProperty<string>(nameof(obj.partyContactID));
    }
}
