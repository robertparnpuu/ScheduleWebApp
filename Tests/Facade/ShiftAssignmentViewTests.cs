using System;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class ShiftAssignmentViewTests : BaseViewTests<ShiftAssignmentView>
    {
        [TestMethod]
        public void ContractIdTest() => IsProperty<string>(nameof(obj.contractId));
        [TestMethod]
        public void OccupationIdTest() => IsProperty<string>(nameof(obj.occupationId));
        [TestMethod]
        public void OccupationNameTest() => IsProperty<string>(nameof(obj.occupationName));
        [TestMethod]
        public void LocationIdTest() => IsProperty<string>(nameof(obj.locationId));
        [TestMethod]
        public void PersonNameTest() => IsProperty<string>(nameof(obj.personName));
        [TestMethod]
        public void LocationNameTest() => IsProperty<string>(nameof(obj.locationName));
        [TestMethod]
        public void StartTimeTest() => IsProperty<DateTime>(nameof(obj.startTime));
        [TestMethod]
        public void EndTimeTest() => IsProperty<DateTime>(nameof(obj.endTime));
        [TestMethod]
        public void DateChoiceTest() => IsProperty<DateTime>(nameof(obj.dateChoice));
    }
}