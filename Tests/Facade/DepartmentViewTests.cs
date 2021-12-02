using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class DepartmentViewTests : BaseViewTests<DepartmentView>
    {
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));
        [TestMethod]
        public void PartyContactIdTest() => IsProperty<string>(nameof(obj.partyContactId));
        [TestMethod]
        public void FullContactTest() => IsProperty<string>(nameof(obj.fullContact));
        [TestMethod]
        public void FullAddressTest() => IsProperty<string>(nameof(obj.fullAddress));
    }
}
