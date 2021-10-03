using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        [TestMethod]
        public void ValidToTest() => IsProperty<DateTime>(nameof(obj.validTo));
        [TestMethod]
        public void ValidFromTest() => IsProperty<DateTime>(nameof(obj.validFrom));

    }
}
