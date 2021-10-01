using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Data.Common;

namespace Tests.Data
{
    [TestClass]
    public class RoleAssignmentDataTests : IdBaseDataTests<RoleAssignmentData,BaseEntityData>
    {
        [TestMethod]
        public void WorkerTest() => IsProperty<string>(nameof(obj.workerId));
        [TestMethod]
        public void RoleTest() => IsProperty<string>(nameof(obj.roleId));
    }
}
