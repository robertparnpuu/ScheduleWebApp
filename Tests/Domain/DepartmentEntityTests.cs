using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class DepartmentEntityTests : NamedEntityTests<Department, DepartmentData>
    {
        [TestMethod]
        public void ContactIdTest() => isReadOnlyProperty(obj.Data.contactId);
    }
}
