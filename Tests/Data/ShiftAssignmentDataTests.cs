using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Data.Common;

namespace Tests.Data
{
    [TestClass]
    public class ShiftAssignmentDataTests : IdBaseDataTests<ShiftAssignmentData,BaseEntityData>
    {
        [TestMethod]
        public void ContractTest() => IsProperty<string>(nameof(obj.contractId));
        [TestMethod]
        public void LocationTest() => IsProperty<string>(nameof(obj.locationId));
        [TestMethod]
        public void StartTimeTest() => IsProperty<DateTime>(nameof(obj.startTime));
        [TestMethod]
        public void EndTimeTest() => IsProperty<DateTime>(nameof(obj.endTime));
    }
}
