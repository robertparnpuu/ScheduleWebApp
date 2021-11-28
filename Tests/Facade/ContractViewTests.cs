using System;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class ContractViewTests : BaseViewTests<ContractView>
    {
        [TestMethod]
        public void PersonIdTest() => IsProperty<string>(nameof(obj.personId));
        [TestMethod]
        public void OccupationIdTest() => IsProperty<string>(nameof(obj.occupationId));
        [TestMethod]
        public void DepartmentIdTest() => IsProperty<string>(nameof(obj.departmentId));
        [TestMethod]
        public void PersonNameTest() => IsProperty<string>(nameof(obj.personName));
        [TestMethod]
        public void OccupationNameTest() => IsProperty<string>(nameof(obj.occupationName));
        [TestMethod]
        public void DepartmentNameTest() => IsProperty<string>(nameof(obj.departmentName));
        [TestMethod]
        public void ValidFromTest() => IsProperty<DateTime>(nameof(obj.validFrom));
        [TestMethod]
        public void ValidToTest() => IsProperty<DateTime>(nameof(obj.validTo));
        [TestMethod]
        public void FullContactTest() => IsProperty<string>(nameof(obj.fullContact));
    }
}
