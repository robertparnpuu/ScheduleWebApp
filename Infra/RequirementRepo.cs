using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class RequirementRepo : BaseRepo<RequirementData, Requirement>, IRequirementRepo
    {
        public RequirementRepo(ApplicationDbContext c) : base(c, c?.Requirements) { }

        public override Requirement ToEntity(RequirementData d) => new(d);
        public override RequirementData ToData(Requirement e) => e?.Data ?? new RequirementData();
    }
}
