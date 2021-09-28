using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain.Common;

namespace Domain
{
    public class OccupationAssignment : BaseEntity<OccupationAssignmentData>
    {
        public Occupation Occupation
        {
            get => default;
            set
            {
            }
        }

        public Worker Worker
        {
            get => default;
            set
            {
            }
        }

        public System.DateTime validFrom
        {
            get => default;
            set
            {
            }
        }

        public System.DateTime validTo
        {
            get => default;
            set
            {
            }
        }
    }
}