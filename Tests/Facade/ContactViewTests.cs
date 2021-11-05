using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class ContactViewTests : BaseViewTests<ContactView>
    {
        [TestMethod]
        public void EmailTest() => IsProperty<string>(nameof(obj.email));
        [TestMethod]
        public void PhoneNumberTest() => IsProperty<string>(nameof(obj.phoneNumber));
    }
}
