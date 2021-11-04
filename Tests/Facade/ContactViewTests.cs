using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class ContactViewTests : BaseViewTests<ContactView>
    {
        [TestMethod]
        public void ContactTypeIdTest() => IsProperty<string>(nameof(obj.contactTypeId));
        [TestMethod]
        public void ContactValueTest() => IsProperty<string>(nameof(obj.contactValue));
        [TestMethod]
        public void AddressIdTest() => IsProperty<string>(nameof(obj.addressId));
    }
}
