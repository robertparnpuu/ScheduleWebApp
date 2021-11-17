using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class LocationEntityTests : NamedEntityTests<Location, LocationData>
    {
        [TestMethod]
        public void ContactIdTest() => isReadOnlyProperty(obj.Data.partyContactId);
        [TestMethod]
        public void LazyReadPartyContactTest() => LazyTest(() => obj.lazyReadPartyContact.IsValueCreated,
        () => obj.partyContact);
    }
}
