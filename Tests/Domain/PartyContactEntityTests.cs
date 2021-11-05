using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class PartyContactEntityTests : BaseEntityTests<PartyContact, PartyContactData>
    {

        [TestMethod]
        public void PartyIdTest() => isReadOnlyProperty(obj.Data.partyId);
        [TestMethod]
        public void ContactIdTest() => isReadOnlyProperty(obj.Data.contactId);
        [TestMethod]
        public void AddressIdTest() => isReadOnlyProperty(obj.Data.addressId);
        [TestMethod]
        public void LazyReadContactTest() => LazyTest(() => obj.lazyReadContact.IsValueCreated,
        () => obj.partyContactContact);
        [TestMethod]
        public void LazyReadAddressTest() => LazyTest(() => obj.lazyReadAddress.IsValueCreated,
        () => obj.partyContactAddress);
    }
}