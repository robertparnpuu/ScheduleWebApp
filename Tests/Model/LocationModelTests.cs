using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class LocationModelTests : WithContactModelTests<Location, LocationView>
    {
        private class TestLocationRepo : TestRepo<Location>, ILocationRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestLocationRepo();
            mockRepoContact = new TestContactRepo();
            mockRepoAddress = new TestAddressRepo();
            mockRepoPartyContact = new TestPartyContactRepo();
            pageModel = new LocationModel((ILocationRepo)mockRepo, (IPartyContactRepo)mockRepoPartyContact,
            (IContactRepo)mockRepoContact, (IAddressRepo)mockRepoAddress, null);
        }

        [TestMethod]
        public void PageTitleTest()
        {
            Assert.AreEqual("Location", pageModel.PageTitle);
        }
    }
}