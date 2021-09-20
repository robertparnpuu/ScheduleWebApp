using Data.Common;
using System;

namespace Data
{
    public class RequirementData : BaseEntityData
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
