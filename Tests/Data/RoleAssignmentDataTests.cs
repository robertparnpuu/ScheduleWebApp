using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Data
{
    [TestClass]
    public class RoleAssignmentDataTests : IdBaseTest<RoleAssignmentData,BaseEntityData>
    {
        [TestMethod]
        public void WorkerTest() => IsProperty<string>(nameof(obj.workerId));
        [TestMethod]
        public void RoleTest() => IsProperty<string>(nameof(obj.roleId));
    }
}
