using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class DepartmentModelTests : ViewedModelTests<Department, DepartmentView>
    {
        private class TestDepartmentRepo : TestRepo<Department>, IDepartmentRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestDepartmentRepo();
            pageModel = new DepartmentModel((IDepartmentRepo) mockRepo, null);
        }
    }
}