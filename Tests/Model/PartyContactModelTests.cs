using Data;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass]
    public class PartyContactModelTests : BaseModelTests<PartyContact, PartyContactView>
    {
        private class TestPartyContactRepo : TestRepo<PartyContact>, IPartyContactRepo { }

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = new TestPartyContactRepo();
            pageModel = new PartyContactModel((IPartyContactRepo)mockRepo, null);
        }
    }
}