using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class Department : WithContact<DepartmentData>
    {
        public Department() : this(null) { }

        public Department(DepartmentData d) : base(d) { }

        public string name => Data?.name ?? "-";
        public string fullAddress => partyContact?.fullAddress ?? "-";
        public string fullContact => partyContact?.fullContact ?? "-";
    }
}