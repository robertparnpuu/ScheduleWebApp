using Data;
using Domain;
using Domain.Repos;
using Infra.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infra
{
    public class ShiftAssignmentRepo : PagedRepo<ShiftAssignmentData, ShiftAssignment>, IShiftAssignmentRepo
    {
        public ShiftAssignmentRepo(ApplicationDbContext c) : base(c, c?.ShiftAssignments) { }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public override ShiftAssignment ToEntity(ShiftAssignmentData d) => new(d);
        public override ShiftAssignmentData ToData(ShiftAssignment e) => e?.Data ?? new ShiftAssignmentData();
        
        protected internal override IQueryable<ShiftAssignmentData> BaseCreateSql() => dbSet.AsNoTracking().Where(x => x.startTime >= startTime && x.startTime <= endTime);

        protected internal override IQueryable<ShiftAssignmentData> applyFilters(IQueryable<ShiftAssignmentData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
            x => x.startTime.ToString().Contains(SearchString) ||
                 x.endTime.ToString().Contains(SearchString));
        }
    }
}
