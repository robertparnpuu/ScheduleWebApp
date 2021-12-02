using System;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class StandardShiftViewTests : BaseViewTests<StandardShiftView>
    {
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));
        [TestMethod]
        public void LocationIdTest() => IsProperty<string>(nameof(obj.locationId));
        [TestMethod]
        public void OccupationIdTest() => IsProperty<string>(nameof(obj.occupationId));
        [TestMethod]
        public void OccupationNameTest() => IsProperty<string>(nameof(obj.occupationName));
        [TestMethod]
        public void LocationNameTest() => IsProperty<string>(nameof(obj.locationName));
        [TestMethod]
        public void StartTimeTest() => IsProperty<DateTime>(nameof(obj.startTime));
        [TestMethod]
        public void EndTimeTest() => IsProperty<DateTime>(nameof(obj.endTime));
    }
}