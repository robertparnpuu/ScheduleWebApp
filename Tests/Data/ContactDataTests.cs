using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Data.Common;

namespace Tests.Data
{
    [TestClass]
    public class ContactDataTests:IdBaseDataTests<ContactData,BaseEntityData>
    {

        [TestMethod]
        public void EmailTest() => IsProperty<string>(nameof(obj.email));
        [TestMethod]
        public void PhoneNumberTest() => IsProperty<string>(nameof(obj.phoneNumber));
    }
}
