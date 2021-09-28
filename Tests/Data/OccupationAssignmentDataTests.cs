using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Data
{
    [TestClass]
    public class OccupationAssignmentDataTests:IdBaseTest<OccupationAssignmentData, BaseEntityData>
    {
        [TestMethod]
        public void WorkerTest() => IsProperty<string>(nameof(obj.workerId));
        [TestMethod]
        public void OccupationTest() => IsProperty<string>(nameof(obj.occupationId));

    }
}
