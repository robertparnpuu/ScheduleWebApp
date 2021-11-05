using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace Domain
{
    public class RoleAssignment : BaseEntity<RoleAssignmentData>
    {
        public RoleAssignment() : this(null) { }

        public RoleAssignment(RoleAssignmentData d) : base(d)
        {
            lazyReadPerson = GetLazy<Person, IPersonRepo>(x => x?.GetEntity(personId));
            lazyReadRole = GetLazy<Role, IRoleRepo>(x => x?.GetEntity(roleId));
        }

        public string roleId => Data?.roleId ?? "-";
        public Role role => lazyReadRole.Value;
        internal Lazy<Role> lazyReadRole { get; }

        public string personId => Data?.personId ?? "-";
        public Person person => lazyReadPerson.Value;
        internal Lazy<Person> lazyReadPerson { get; }

        public DateTime validFrom => Data.validFrom;
        public DateTime validTo => Data.validTo;
    }
}