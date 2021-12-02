using System;

namespace Domain.Repos
{
    public interface IShiftAssignmentRepo : IRepo<ShiftAssignment>
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
