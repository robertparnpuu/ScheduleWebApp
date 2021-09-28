using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Data
{
    [TestClass]
    public class ContactDataTests:IdBaseTest<ContactData,BaseEntityData>
    {
        [TestMethod]
        public void EmailTest() => IsProperty<string>(nameof(obj.email));
        [TestMethod]
        public void PhoneNumberTest() => IsProperty<string>(nameof(obj.phoneNumber));
        [TestMethod]
        public void AddressTest() => IsProperty<string>(nameof(obj.addressId));
    }
}
