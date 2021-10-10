using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class ContactEntityTests : BaseEntityTests<Contact, ContactData>
    {
        [TestMethod]
        public void ApartmentNumberTest() => isReadOnlyProperty(obj.Data.email);
        [TestMethod]
        public void StreetNameTest() => isReadOnlyProperty(obj.Data.phoneNumber);
        [TestMethod]
        public void HouseNumberTest() => isReadOnlyProperty(obj.Data.addressId);
    }
}
