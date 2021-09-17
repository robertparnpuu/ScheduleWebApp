using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class RequirementData : BaseEntityData
    {
        public int locationId { get; set;  }
        public int occupationId { get; set;  }
        public int weekDayId { get; set; }
        //Todo: Better name than startTimeClock
        public DateTime startTime {  get; set; }
        public DateTime endTime {  get; set; }

        public int minEmployees { get; set; }   
        public int maxEmployees {  get; set; }  

    }
}
