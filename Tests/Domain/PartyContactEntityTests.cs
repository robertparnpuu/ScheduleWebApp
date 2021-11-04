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
        public void ContactIdTest() => isReadOnlyProperty(obj.Data.contactId);
        [TestMethod]
        public void LazyReadPersonTest() => LazyTest(() => obj.lazyReadPerson.IsValueCreated,
        () => obj.partyContactPerson);
        [TestMethod]
        public void LazyReadAddressTest() => LazyTest(() => obj.lazyReadContact.IsValueCreated,
        () => obj.partyContactContact);
    }
}