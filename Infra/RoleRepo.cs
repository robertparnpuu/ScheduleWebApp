using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class RoleRepo : PagedRepo<RoleData, Role>, IRoleRepo
    {
        public RoleRepo(ApplicationDbContext c) : base(c, c?.Roles) { }

        public override Role ToEntity(RoleData d) => new(d);
        public override RoleData ToData(Role e) => e?.Data ?? new RoleData();
    }
}
