using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class WorkerEntityTests : BaseEntityTests<Worker, WorkerData>
    {
        [TestMethod]
        public void PersonIdTest() => isReadOnlyProperty(obj.Data.personId);
        [TestMethod]
        public void DepartmentIdTest() => isReadOnlyProperty(obj.Data.departmentId);
    }
}
