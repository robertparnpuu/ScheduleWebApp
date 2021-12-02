using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Data.Common;

namespace Tests.Data
{
    [TestClass]
    public class PartyContactTests : IdBaseDataTests<PartyContactData, BaseEntityData>
    {
        [TestMethod]
        public void ContactIdTest() => IsProperty<string>(nameof(obj.contactId));
        [TestMethod]
        public void PartyIdTest() => IsProperty<string>(nameof(obj.partyId));
    }
}