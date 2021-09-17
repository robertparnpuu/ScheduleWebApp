using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Worker
    {
        public Department Department
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

        public List<RoleAssignment> RoleAssignments
        {
            get => default;
            set
            {
            }
        }

        public List<OccupationAssignment> OccupationAssignments
        {
            get => default;
            set
            {
            }
        }

        public Person Person
        {
            get => default;
            set
            {
            }
        }
    }
}