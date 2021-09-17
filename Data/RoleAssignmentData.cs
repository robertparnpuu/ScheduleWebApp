using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class RoleAssignmentData : BaseEntityData
    {
        public int workerId {  get; set; }
        public int roleId { get; set; }
    }
}
