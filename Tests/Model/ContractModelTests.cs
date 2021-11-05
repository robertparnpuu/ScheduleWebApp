using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class ContractModelTests : BaseModelTests<Contract, ContractView>
    {
        private class TestContractRepo : TestRepo<Contract>, IContractRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestContractRepo();
            pageModel = new ContractModel((IContractRepo) mockRepo, null);
        }
    }
}