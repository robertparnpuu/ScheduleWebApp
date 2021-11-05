using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class AddressRepo : BaseRepo<AddressData, Address>, IAddressRepo
    {
        public AddressRepo(ApplicationDbContext c) : base(c, c?.Addresses){ }

        public override Address ToEntity(AddressData d) => new(d);
        public override AddressData ToData(Address e) => e?.Data ?? new AddressData();
    }
}
