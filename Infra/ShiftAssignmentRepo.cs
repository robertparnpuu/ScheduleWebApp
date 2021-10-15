using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class ShiftAssignmentRepo : BaseRepo<ShiftAssignmentData, ShiftAssignment>, IShiftAssignmentRepo
    {
        public ShiftAssignmentRepo(ApplicationDbContext c) : base(c, c?.ShiftAssignments) { }

        public override ShiftAssignment ToEntity(ShiftAssignmentData d) => new(d);
        public override ShiftAssignmentData ToData(ShiftAssignment e) => e?.Data ?? new ShiftAssignmentData();
    }
}
