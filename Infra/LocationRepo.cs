using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class LocationRepo : BaseRepo<LocationData, Location>, ILocationRepo
    {
        public LocationRepo(ApplicationDbContext c) : base(c, c?.Locations) { }

        public override Location ToEntity(LocationData d) => new(d);
        public override LocationData ToData(Location e) => e?.Data ?? new LocationData();

    }
}
