using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class OccupationAssignmentRepo : BaseRepo<OccupationAssignmentData, OccupationAssignment>, IOccupationAssignmentRepo
    {
        public OccupationAssignmentRepo(ApplicationDbContext c) : base(c, c?.OccupationAssignments) { }

        public override OccupationAssignment ToEntity(OccupationAssignmentData d) => new(d);
        public override OccupationAssignmentData ToData(OccupationAssignment e) => e?.Data ?? new OccupationAssignmentData();
    }
}
