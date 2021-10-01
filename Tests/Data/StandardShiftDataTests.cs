﻿using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Data
{
    [TestClass]
    public class StandardShiftDataTests : IdBaseTest<StandardShiftData,NamedEntityData>
    {
        [TestMethod]
        public void OccupationTest() => IsProperty<string>(nameof(obj.occupationId));
        [TestMethod]
        public void LocationTest() => IsProperty<string>(nameof(obj.locationId));
        [TestMethod]
        public void StartTimeTest() => IsProperty<DateTime>(nameof(obj.startTime));
        [TestMethod]
        public void EndTimeTest() => IsProperty<DateTime>(nameof(obj.endTime));
    }
}
