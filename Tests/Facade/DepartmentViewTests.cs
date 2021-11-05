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
        public void ContactIdTest() => IsProperty<string>(nameof(obj.contactId));
        [TestMethod]
        public void DepartmentEmailTest() => IsProperty<string>(nameof(obj.departmentEmail));
        [TestMethod]
        public void DepartmentPhoneNrTest() => IsProperty<string>(nameof(obj.departmentPhoneNr));
    }
}
