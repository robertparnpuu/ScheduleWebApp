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
        public void AddressIdTest() => IsProperty<string>(nameof(obj.addressId));
        [TestMethod]
        public void ContactTypeIdTest() => IsProperty<string>(nameof(obj.contactTypeId));
        [TestMethod]
        public void ContactValueTest() => IsProperty<string>(nameof(obj.contactValue));
    }
}
