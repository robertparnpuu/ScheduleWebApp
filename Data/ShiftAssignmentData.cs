using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class ShiftAssignmentData : BaseEntityData
    {
        public int workerId { get; set; }
        public int locationId { get; set; }     
        public DateTime startTime { get; set; }
        public DateTime endTime {  get; set; }
    }
}
