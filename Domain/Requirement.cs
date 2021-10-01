using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain.Common;

namespace Domain
{
    public class Requirement : BaseEntity<RequirementData>
    {
        public Location Location
        {
            get => default;
            set
            {
            }
        }

        public Occupation Occupation
        {
            get => default;
            set
            {
            }
        }

        public int MinEmployees 
        {
            get => default;
            set
            {
            }
        }

        public int MaxEmployees
        {
            get => default;
            set
            {
            }
        }

        public System.DateTime StartTimeClock
        {
            get => default;
            set
            {
            }
        }

        public System.DateTime EndTimeClock
        {
            get => default;
            set
            {
            }
        }

        public WeekDay DayOfWeek
        {
            get => default;
            set
            {
            }
        }
    }
}