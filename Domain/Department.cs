using Data;
using Domain.Common;

namespace Domain
{
    public class Department : WithContact<DepartmentData>
    {
        public Department() : this(null) { }

        public Department(DepartmentData d) : base(d) { }

        public string name => Data?.name ?? "-";
        public string fullAddress => partyContact?.fullAddress ?? "-";
    }
}