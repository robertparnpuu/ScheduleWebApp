using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Data
{
    [TestClass]
    public class ShiftAssignmentDataTests : IdBaseTest<ShiftAssignmentData,BaseEntityData>
    {
        [TestMethod]
        public void WorkerTest() => IsProperty<string>(nameof(obj.workerId));
        [TestMethod]
        public void LocationTest() => IsProperty<string>(nameof(obj.locationId));
        [TestMethod]
        public void StartTimeTest() => IsProperty<DateTime>(nameof(obj.startTime));
        [TestMethod]
        public void EndTimeTest() => IsProperty<DateTime>(nameof(obj.endTime));
    }
}
