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
        public void AddressIdTest() => isReadOnlyProperty(obj.Data.addressId);
        [TestMethod]
        public void ContactTypeIdTest() => isReadOnlyProperty(obj.Data.contactTypeId);
        [TestMethod]
        public void ContactValueTest() => isReadOnlyProperty(obj.Data.contactValue);
        [TestMethod]
        public void LazyReadAddressTest() => LazyTest(() => obj.lazyReadAddress.IsValueCreated,
        () => obj.contactAddress);
        [TestMethod]
        public void LazyReadContactTypeTest() => LazyTest(() => obj.lazyReadContactType.IsValueCreated,
        () => obj.contactContactType);
    }
}
