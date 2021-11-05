using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class PartyContactViewTests : BaseViewTests<PartyContactView>
    {
        [TestMethod]
        public void ContactIdTest() => IsProperty<string>(nameof(obj.contactId));
        [TestMethod]
        public void PartyIdTest() => IsProperty<string>(nameof(obj.partyId));
        [TestMethod]
        public void AddressIdTest() => IsProperty<string>(nameof(obj.addressId));
    }
}