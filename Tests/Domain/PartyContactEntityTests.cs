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
        public void PersonIdTest() => isReadOnlyProperty(obj.Data.personId);
        [TestMethod]
        public void AddressIdTest() => isReadOnlyProperty(obj.Data.addressId);
        [TestMethod]
        public void ContactIdTest() => isReadOnlyProperty(obj.Data.contactId);
        [TestMethod]
        public void LazyReadAddressTest() => LazyTest(() => obj.lazyReadAddress.IsValueCreated,
        () => obj.partyContactAddress);
        [TestMethod]
        public void LazyReadPartyContactTest() => LazyTest(() => obj.lazyReadContact.IsValueCreated,
        () => obj.partyContactContact);
    }
}