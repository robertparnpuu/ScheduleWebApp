using Data;
using Domain;
using Domain.Repos;
using Infra.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra
{
    public class ShiftAssignmentRepo : PagedRepo<ShiftAssignmentData, ShiftAssignment>, IShiftAssignmentRepo
    {
        public ShiftAssignmentRepo(ApplicationDbContext c) : base(c, c?.ShiftAssignments) { }

        public override ShiftAssignment ToEntity(ShiftAssignmentData d) => new(d);
        public override ShiftAssignmentData ToData(ShiftAssignment e) => e?.Data ?? new ShiftAssignmentData();

        public override async Task<List<ShiftAssignmentData>> GetDataListAsync(DateTime dt1, DateTime dt2)
        {
            return await dbSet.Where(x => x.startTime >= dt1 && x.startTime <= dt2).ToListAsync();
        }
    }
}
