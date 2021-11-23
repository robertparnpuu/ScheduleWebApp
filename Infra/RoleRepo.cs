using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class RoleRepo : BaseRepo<RoleData, Role>, IRoleRepo
    {
        public RoleRepo(ApplicationDbContext c) : base(c, c?.Roles2) { }

        public override Role ToEntity(RoleData d) => new(d);
        public override RoleData ToData(Role e) => e?.Data ?? new RoleData();
    }
}
