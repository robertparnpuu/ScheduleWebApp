using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class PartyContactViewTests : BaseViewTests<PartyContactView>
    {
        [TestMethod]
        public void FullContactTest() => IsProperty<string>(nameof(obj.fullContact));
        [TestMethod]
        public void FullAddressTest() => IsProperty<string>(nameof(obj.fullAddress));
    }
}