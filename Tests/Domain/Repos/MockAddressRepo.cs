using Domain;
using Domain.Repos;
using Tests.Model.Common;

namespace Tests.Domain.Repos
{
    public class MockAddressRepo :TestRepo<Address>, IAddressRepo { }
}