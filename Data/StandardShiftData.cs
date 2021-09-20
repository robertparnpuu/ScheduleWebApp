using Data.Common;
using System;

namespace Data
{
    public class StandardShiftData : BaseEntityData
    {
        public int locationId { get; set; }
        public int occupationId { get; set;  }
        public DateTime startTime { get; set; }
        public DateTime endTime {  get; set; } 
    }
}
