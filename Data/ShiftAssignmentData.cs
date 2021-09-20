using Data.Common;
using System;

namespace Data
{
    public class ShiftAssignmentData : BaseEntityData
    {
        public int workerId { get; set; }
        public int locationId { get; set; }     
        public DateTime startTime { get; set; }
        public DateTime endTime {  get; set; }
    }
}
