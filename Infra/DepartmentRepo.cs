using System.Linq;
using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class DepartmentRepo : PagedRepo<DepartmentData, Department>, IDepartmentRepo
    {
        public DepartmentRepo(ApplicationDbContext c) : base(c, c?.Departments) { }

        public override Department ToEntity(DepartmentData d) => new(d);
        public override DepartmentData ToData(Department e) => e?.Data ?? new DepartmentData();

        protected internal override IQueryable<DepartmentData> applyFilters(IQueryable<DepartmentData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
            x => x.name.Contains(SearchString));
        }
    }
}
