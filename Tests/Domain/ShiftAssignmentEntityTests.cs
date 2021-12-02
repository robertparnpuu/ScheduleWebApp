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
        public void ContractIdTest() => isReadOnlyProperty(obj.Data.contractId);
        [TestMethod]
        public void StartTimeTest() => isReadOnlyProperty(obj.Data.startTime);
        [TestMethod]
        public void EndTimeTest() => isReadOnlyProperty(obj.Data.endTime);
        [TestMethod]
        public void LocationIdTest() => isReadOnlyProperty(obj.Data.locationId);

        [TestMethod]
        public void LazyReadContractTest() => LazyTest(() => obj.lazyReadContract.IsValueCreated,
        () => obj.shiftAssignmentContract);

        [TestMethod]
        public void LazyReadLocationTest() => LazyTest(() => obj.lazyReadLocation.IsValueCreated,
        () => obj.shiftAssignmentLocation);
    }
}