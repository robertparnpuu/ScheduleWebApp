using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class LocationViewTests : BaseViewTests<LocationView>
    {
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));
        [TestMethod]
        public void ContactIdTest() => IsProperty<string>(nameof(obj.contactId));
        [TestMethod]
        public void FullContactTest() => IsProperty<string>(nameof(obj.fullContact));
    }
}