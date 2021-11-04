using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class PersonEntityTests : BaseEntityTests<Person, PersonData>
    {
        [TestMethod]
        public void FirstNameTest() => isReadOnlyProperty(obj.Data.firstName);
        [TestMethod]
        public void LastNameTest() => isReadOnlyProperty(obj.Data.lastName);
        [TestMethod]
        public void DateOfBirthTest() => isReadOnlyProperty(obj.Data.dateOfBirth);
        [TestMethod]
        public void IdCodeTest() => isReadOnlyProperty(obj.Data.idCode);
        [TestMethod]
        public void RoleAssignmentIdTest() => isReadOnlyProperty(obj.Data.roleAssignmentId);

        [TestMethod]
        public void LazyReadAddressTest() => Assert.Inconclusive();
    }
}
