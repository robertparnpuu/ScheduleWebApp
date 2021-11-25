using Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Common
{
    [TestClass]
    public class WithContactViewTests : BaseViewTests<WithContactView>
    {
        [TestMethod]
        public void AddressIdTest() => IsProperty<string>(nameof(obj.addressId));
        [TestMethod]
        public void ContactIdTest() => IsProperty<string>(nameof(obj.contactId));
        [TestMethod]
        public void PartyIdTest() => IsProperty<string>(nameof(obj.partyId));
        [TestMethod]
        public void PartyContactIdTest() => IsProperty<string>(nameof(obj.partyContactId));
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
        public void EmailTest() => IsProperty<string>(nameof(obj.email));
        [TestMethod]
        public void PhoneNumberTest() => IsProperty<string>(nameof(obj.phoneNumber));
    }
}
