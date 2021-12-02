using System.Linq;
using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class LocationRepo : PagedRepo<LocationData, Location>, ILocationRepo
    {
        public LocationRepo(ApplicationDbContext c) : base(c, c?.Locations) { }

        public override Location ToEntity(LocationData d) => new(d);
        public override LocationData ToData(Location e) => e?.Data ?? new LocationData();

        protected internal override IQueryable<LocationData> applyFilters(IQueryable<LocationData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
            x => x.name.Contains(SearchString));
        }

    }
}
