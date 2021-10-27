using System;
using Data.Common;

namespace Data
{
    public class OccupationAssignmentData : BaseEntityData
    {
        public string personId { get; set;  }
        public string occupationId { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validTo { get; set; }
        public string departmentId { get; set; }
    }
}
