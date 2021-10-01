using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain.Common;

namespace Domain
{
    public class ShiftAssignment : BaseEntity<ShiftAssignmentData>
    {

        public Worker Worker
        {
            get => default;
            set
            {
            }
        }

        public DateTime EndTime
        {
            get => default;
            set
            {
            }
        }

        public DateTime StartTime
        {
            get => default;
            set
            {
            }
        }

        public Location Location
        {
            get => default;
            set
            {
            }
        }
    }
}