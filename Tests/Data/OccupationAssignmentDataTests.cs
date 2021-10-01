using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Data.Common;


namespace Tests.Data
{
    [TestClass]
    public class OccupationAssignmentDataTests:IdBaseDataTests<OccupationAssignmentData, BaseEntityData>
    {
        [TestMethod]
        public void WorkerTest() => IsProperty<string>(nameof(obj.workerId));
        [TestMethod]
        public void OccupationTest() => IsProperty<string>(nameof(obj.occupationId));

    }
}
