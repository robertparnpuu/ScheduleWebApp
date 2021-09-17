using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class StandardShiftData : BaseEntityData
    {
        public int locationId { get; set; }
        public int occupationId { get; set;  }
        public DateTime startTime { get; set; }
        public DateTime endTime {  get; set; } 
    }
}
