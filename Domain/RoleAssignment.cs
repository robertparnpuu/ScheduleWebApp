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
        public RoleAssignment() : this(null) { }
        public RoleAssignment(RoleAssignmentData d) : base(d) { }

        public string roleId => Data.roleId;
        public Role role => lazyReadRole.Value;
        internal Lazy<Role> lazyReadRole { get; }

        public string workerId => Data.workerId;
        public Worker worker => lazyReadWorker.Value;
        internal Lazy<Worker> lazyReadWorker { get; }

        public DateTime validFrom => Data.validFrom;
        public DateTime validTo => Data.validTo;
    }
}