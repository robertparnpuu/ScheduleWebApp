using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class PersonModelTests : WithContactModelTests<Person, PersonView>
    {
        private class TestPersonRepo : TestRepo<Person>, IPersonRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestPersonRepo();
            mockRepoContact = new TestContactRepo();
            mockRepoAddress = new TestAddressRepo();
            mockRepoPartyContact = new TestPartyContactRepo();
            pageModel = new PersonModel((IPersonRepo)mockRepo, (IPartyContactRepo)mockRepoPartyContact,
            (IContactRepo)mockRepoContact, (IAddressRepo)mockRepoAddress, null);
        }

        [TestMethod]
        public void PageTitleTest()
        {
            Assert.AreEqual("Person", pageModel.PageTitle);
        }
    }
}