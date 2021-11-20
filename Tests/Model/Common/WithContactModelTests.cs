using Core;
using Domain;
using Domain.Repos;

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
    }
}
