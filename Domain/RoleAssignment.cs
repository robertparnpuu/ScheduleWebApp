using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain.Common;

namespace Domain
{
    public class RoleAssignment : BaseEntity<RoleAssignmentData>
    {
        public Role Role
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