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
        public void HouseNumberTest() => isReadOnlyProperty(obj.Data.addressId);

        [TestMethod]
        public void LazyReadAddressTest() => LazyTest(() => obj.lazyReadAddress.IsValueCreated,
        () => obj.contactAddress);
    }
}
