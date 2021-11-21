using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class RoleAssignmentRepo : PagedRepo<RoleAssignmentData, RoleAssignment>, IRoleAssignmentRepo
    {
        public RoleAssignmentRepo(ApplicationDbContext c) : base(c, c?.RoleAssignments) { }

        public override RoleAssignment ToEntity(RoleAssignmentData d) => new(d);
        public override RoleAssignmentData ToData(RoleAssignment e) => e?.Data ?? new RoleAssignmentData();
    }
}
