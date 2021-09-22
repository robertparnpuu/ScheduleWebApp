using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.Common;
using Domain.Common;

namespace Domain
{
    public class Department : BaseEntity<DepartmentData>
    {
        public Contact Contact
        {
            get => default;
            set
            {
            }
        }

        public List<Worker> Workers
        {
            get => default;
            set
            {
            }
        }
    }
}