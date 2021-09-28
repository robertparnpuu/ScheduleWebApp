using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain.Common;

namespace Domain
{
    public class Location : BaseEntity<LocationData>
    {

        public int LocationID
        {
            get => default;
            set
            {
            }
        }

        public List<ShiftAssignment> ShiftAssignments
        {
            get => default;
            set
            {
            }
        }

        public Contact Contact
        {
            get => default;
            set
            {
            }
        }
    }
}