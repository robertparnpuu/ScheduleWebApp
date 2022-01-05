using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass]
    public class PartyContactModelTests : ViewedModelTests<PartyContact, PartyContactView>
    {
        private class TestPartyContactRepo : TestRepo<PartyContact>, IPartyContactRepo { }

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = new TestPartyContactRepo();
            pageModel = new PartyContactModel((IPartyContactRepo)mockRepo, null);
        }

        [TestMethod]
        public void PageTitleTest()
        {
            Assert.AreEqual("PartyContact", pageModel.PageTitle);
        }
    }
}