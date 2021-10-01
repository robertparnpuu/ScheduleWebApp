using Data;
using Domain.Common;

namespace Domain
{
    public class Role : BaseEntity<RoleData>
    {
        public Role() : this(null) { }
        public Role(RoleData d) : base(d) { }
        public string name => Data?.name ?? ".";
    }
}