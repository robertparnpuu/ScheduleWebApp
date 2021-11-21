using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class ContractRepo : PagedRepo<ContractData, Contract>, IContractRepo
    {
        public ContractRepo(ApplicationDbContext c) : base(c, c?.Contracts) { }

        public override Contract ToEntity(ContractData d) => new(d);
        public override ContractData ToData(Contract e) => e?.Data ?? new ContractData();
    }
}
