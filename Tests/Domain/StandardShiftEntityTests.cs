using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class StandardShiftTests : NamedEntityTests<StandardShift, StandardShiftData>
    {
        [TestMethod]
        public void StartTimeTest() => isReadOnlyProperty(obj.Data.startTime);
        [TestMethod]
        public void EndTimeTest() => isReadOnlyProperty(obj.Data.endTime);
        [TestMethod]
        public void LocationTest() => isReadOnlyProperty(obj.Data.locationId);
        [TestMethod]
        public void OccupationTest() => isReadOnlyProperty(obj.Data.occupationId);
    }
}
