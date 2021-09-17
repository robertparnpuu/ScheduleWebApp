using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class WorkerData : PersonData
    {
        public int personId { get; set; }
        public int roleAssignmentId {  get; set; }
        public int occupationAssignmentId { get; set; }
        public int departmentId { get; set; }   
    }
}
