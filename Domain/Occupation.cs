using System.Collections.Generic;
using Data;
using Domain.Common;

namespace Domain
{
    public class Occupation : BaseEntity<OccupationData>
    {
        public int OccupationId
        {
            get => default;
            set
            {
            }
        }

        public string OccupationName
        {
            get => default;
            set
            {
            }
        }

        public List<OccupationAssignment> OccupationAssignment
        {
            get => default;
            set
            {
            }
        }
    }
}