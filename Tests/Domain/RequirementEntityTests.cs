using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class RequirementEntityTests : BaseEntityTests<Requirement, RequirementData>
    {
        [TestMethod]
        public void LocationIdTest() => isReadOnlyProperty(obj.Data.locationId);
        [TestMethod]
        public void OccupationIdTest() => isReadOnlyProperty(obj.Data.occupationId);
        [TestMethod]
        public void MinEmployeesTest() => isReadOnlyProperty(obj.Data.minEmployees);
        [TestMethod]
        public void MaxEmployeesTest() => isReadOnlyProperty(obj.Data.maxEmployees);
        [TestMethod]
        public void StartTimeClockTest() => isReadOnlyProperty(obj.Data.startTime);
        [TestMethod]
        public void EndTimeClockTest() => isReadOnlyProperty(obj.Data.endTime);
        [TestMethod]
        public void WeekdayIdTest() => isReadOnlyProperty(obj.Data.weekDayId);

        [TestMethod]
        public void LazyReadLocationTest() => LazyTest(() => obj.lazyReadLocation.IsValueCreated,
        () => obj.requiredLocation);
        [TestMethod]
        public void LazyReadOccupationTest() => LazyTest(() => obj.lazyReadOccupation.IsValueCreated,
        () => obj.requiredOccupation);

        [TestMethod]
        public void LazyReadWeekDayTest() => LazyTest(() => obj.lazyReadWeekDay.IsValueCreated,
        () => obj.requiredWeekDays);
    }
}
