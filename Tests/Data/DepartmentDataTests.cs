using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class DepartmentDataTests:BaseTests<DepartmentData,NamedEntityData>
    {
        [TestMethod]
        public void ContactTest() => IsProperty<string>(nameof(obj.contactId));
        [TestMethod]
        public void IDTest() => IsProperty<string>(nameof(obj.id));
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));
    }
}
