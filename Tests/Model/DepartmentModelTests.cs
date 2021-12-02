using Aids;
using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class DepartmentModelTests : WithContactModelTests<Department, DepartmentView>
    {
        private class TestDepartmentRepo : TestRepo<Department>, IDepartmentRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestDepartmentRepo();
            mockRepoContact = new TestContactRepo();
            mockRepoAddress = new TestAddressRepo();
            mockRepoPartyContact = new TestPartyContactRepo();
            pageModel = new DepartmentModel((IDepartmentRepo) mockRepo, (IPartyContactRepo)mockRepoPartyContact, 
            (IContactRepo)mockRepoContact, (IAddressRepo)mockRepoAddress, null);
        }
    }
}