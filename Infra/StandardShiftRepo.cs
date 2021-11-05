using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class StandardShiftRepo : BaseRepo<StandardShiftData, StandardShift>, IStandardShiftRepo
    {
        public StandardShiftRepo(ApplicationDbContext c) : base(c, c?.StandardShifts) { }

        public override StandardShift ToEntity(StandardShiftData d) => new(d);
        public override StandardShiftData ToData(StandardShift e) => e?.Data ?? new StandardShiftData();
    }
}
