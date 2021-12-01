using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IShiftAssignmentRepo : IRepo<ShiftAssignment>
    {
        Task<List<ShiftAssignment>> GetEntityListAsync(DateTime dt1, DateTime dt2);
    }
}
