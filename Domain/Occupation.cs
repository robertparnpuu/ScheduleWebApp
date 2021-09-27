using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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