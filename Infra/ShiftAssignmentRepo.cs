using Data;
using Domain;
using Domain.Repos;
using Infra.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

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

        public override async Task<bool> AddAsync(ShiftAssignmentData obj)
        {
            if (IsPersonFree(ToEntity(obj))) return await base.AddAsync(obj);
            ErrorMessage = ErrorMessages.PersonNotFree;
            return false;

        }

        private bool IsRequirementsMet(ShiftAssignment e)
        {
            IsPersonFree(e);
            return true;
        }

        private bool IsPersonFree(ShiftAssignment e)
        {
            //TODO hetkel ainult kuupäevaga, ei saanud tööle kellaajaliselt

            var itemInDataBase = dbSet.SingleOrDefault(
            r => r.contractId == e.contractId && 
                 r.startTime.Date == e.startTime.Date &&
                 e.id != r.id);
            return itemInDataBase == null;
        }
    }
}
