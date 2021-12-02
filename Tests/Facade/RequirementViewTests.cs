using System;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class RequirementViewTests : BaseViewTests<RequirementView>
    {
        [TestMethod]
        public void LocationIdTest() => IsProperty<string>(nameof(obj.locationId));
        [TestMethod]
        public void LocationNameTest() => IsProperty<string>(nameof(obj.locationName));
        [TestMethod]
        public void OccupationIdTest() => IsProperty<string>(nameof(obj.occupationId));
        [TestMethod]
        public void OccupationNameTest() => IsProperty<string>(nameof(obj.occupationName));
        [TestMethod]
        public void WeekDayNameTest() => IsProperty<string>(nameof(obj.weekDayName));
        [TestMethod]
        public void WeekDayIdTest() => IsProperty<string>(nameof(obj.weekDayId));
        [TestMethod]
        public void StartTimeTest() => IsProperty<DateTime>(nameof(obj.startTime));
        [TestMethod]
        public void EndTimeTest() => IsProperty<DateTime>(nameof(obj.endTime));
        [TestMethod]
        public void MinEmployeesTest() => IsProperty<int>(nameof(obj.minEmployees));
        [TestMethod]
        public void MaxEmployeesTest() => IsProperty<int>(nameof(obj.maxEmployees));
    }
}