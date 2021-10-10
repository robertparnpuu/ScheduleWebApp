using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class ShiftAssignmentEntityTests : BaseEntityTests<ShiftAssignment, ShiftAssignmentData>
    {
        [TestMethod]
        public void WorkerIdTest() => isReadOnlyProperty(obj.Data.workerId);
        [TestMethod]
        public void StartTimeTest() => isReadOnlyProperty(obj.Data.startTime);
        [TestMethod]
        public void EndTimeTest() => isReadOnlyProperty(obj.Data.endTime);
        [TestMethod]
        public void LocationIdTest() => isReadOnlyProperty(obj.Data.locationId);
    }
}