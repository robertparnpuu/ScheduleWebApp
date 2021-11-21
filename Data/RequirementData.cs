using Data.Common;
using System;

namespace Data
{
    public class RequirementData : BaseEntityData
    {

        public string locationId { get; set;  }
        public string occupationId { get; set;  }
        public string weekDayId { get; set; }
        public DateTime startTime {  get; set; }
        public DateTime endTime {  get; set; }

        public int minEmployees { get; set; }   
        public int maxEmployees {  get; set; }  

    }
}
