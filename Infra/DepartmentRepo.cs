using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class DepartmentRepo : BaseRepo<DepartmentData, Department>, IDepartmentRepo
    {
        public DepartmentRepo(ApplicationDbContext c) : base(c, c?.Departments) { }

        public override Department ToEntity(DepartmentData d) => new(d);
        public override DepartmentData ToData(Department e) => e?.Data ?? new DepartmentData();
    }
}
