using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class AddressModelTests : BaseModelTests<Address, AddressView>
    {
        private class TestAddressRepo : TestRepo<Address>, IAddressRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestAddressRepo();
            pageModel = new AddressModel((IAddressRepo) mockRepo, null);
        }
    }
}