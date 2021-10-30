using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class RoleAssignmentEntityTests : BaseEntityTests<RoleAssignment, RoleAssignmentData>
    {
        [TestMethod]
        public void RoleIdTest() => isReadOnlyProperty(obj.Data.roleId);
        [TestMethod]
        public void PersonIdTest() => isReadOnlyProperty(obj.Data.personId);
        [TestMethod]
        public void ValidFromTest() => isReadOnlyProperty(obj.Data.validFrom);
        [TestMethod]
        public void ValidToTest() => isReadOnlyProperty(obj.Data.validTo);
        [TestMethod]
        public void LazyReadPersonTest() => LazyTest(() => obj.lazyReadPerson.IsValueCreated,
        () => obj.person);

        [TestMethod]
        public void LazyReadRoleTest() => LazyTest(() => obj.lazyReadRole.IsValueCreated,
        () => obj.role);
    }
}
