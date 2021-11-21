using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class OccupationRepo : PagedRepo<OccupationData, Occupation>, IOccupationRepo
    {
        public OccupationRepo(ApplicationDbContext c) : base(c, c?.Occupations) { }

        public override Occupation ToEntity(OccupationData d) => new(d);
        public override OccupationData ToData(Occupation e) => e?.Data ?? new OccupationData();
    }
}
