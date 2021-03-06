using Data.Common;
using System;

namespace Data
{
    public class ShiftAssignmentData : BaseEntityData
    {
        public string contractId { get; set; }
        public string locationId { get; set; }     
        public DateTime startTime { get; set; }
        public DateTime endTime {  get; set; }
    }
}
