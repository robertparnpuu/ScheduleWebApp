using Data.Common;
using System;

namespace Data
{
    public class StandardShiftData : NamedEntityData
    {
        public string locationId { get; set; }
        public string occupationId { get; set;  }
        public DateTime startTime { get; set; }
        public DateTime endTime {  get; set; } 
    }
}
