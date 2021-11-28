using Aids;
using Core;
using Data;
using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Model.Common
{
    public class WithContactModelTests<TEntity, TView> : ViewedModelTests<TEntity, TView>
    where TEntity : IBaseEntity, new()
    where TView : IBaseEntity
    {
        protected class TestContactRepo : TestRepo<Contact>, IContactRepo { }
        protected class TestPartyContactRepo : TestRepo<PartyContact>, IPartyContactRepo { }
        protected class TestAddressRepo : TestRepo<Address>, IAddressRepo { }

        protected TestRepo<Contact> mockRepoContact;
        protected TestRepo<Address> mockRepoAddress;
        protected TestRepo<PartyContact> mockRepoPartyContact;
        protected TView view;

        [TestMethod] 
        public void ToEntityAddressTestItemIsNull() => Assert.IsNull(pageModel.ToEntityAddress(null));
        [TestMethod] 
        public void ToEntityContactTestItemIsNull() => Assert.IsNull(pageModel.ToEntityContact(null));
        [TestMethod] 
        public void ToEntityPartyContactTestItemIsNull() => Assert.IsNull(pageModel.ToEntityPartyContact(null));

        [TestMethod]
        public void ToEntityAddressTest()
        {
            view = GetRandom.ObjectOf<TView>();
            pageModel.item = view;
            Assert.IsNotNull(pageModel.ToEntityAddress(view));
        }

        [TestMethod]
        public void ToEntityContactTest()
        {
            view = GetRandom.ObjectOf<TView>();
            pageModel.item = view;
            Assert.IsNotNull(pageModel.ToEntityContact(view));
        }

        [TestMethod]
        public void ToEntityPartyContactTest()
        {
            view = GetRandom.ObjectOf<TView>();
            pageModel.item = view;
            Assert.IsNotNull(pageModel.ToEntityPartyContact(view));
        }
    }
}
