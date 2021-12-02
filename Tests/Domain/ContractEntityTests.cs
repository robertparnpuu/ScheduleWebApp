using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class ContractTests : BaseEntityTests<Contract, ContractData>
    {
        [TestMethod]
        public void OccupationIdTest() => isReadOnlyProperty(obj.Data.occupationId);
        [TestMethod]
        public void WorkerIdTest() => isReadOnlyProperty(obj.Data.personId);
        [TestMethod]
        public void ValidFromTest() => isReadOnlyProperty(obj.Data.validFrom);
        [TestMethod]
        public void ValidToTest() => isReadOnlyProperty(obj.Data.validTo);
        [TestMethod]
        public void DepartmentTest() => isReadOnlyProperty(obj.Data.departmentId);

        [TestMethod]
        public void LazyReadOccupationTest() => LazyTest(() => obj.lazyReadOccupation.IsValueCreated,
        () => obj.contractOccupation);

        [TestMethod]
        public void LazyReadPersonTest() => LazyTest(() => obj.lazyReadPerson.IsValueCreated,
        () => obj.contractPerson);

        [TestMethod]
        public void LazyReadDepartmentTest() => LazyTest(() => obj.lazyReadDepartment.IsValueCreated,
        () => obj.contractDepartment);
    }
}
