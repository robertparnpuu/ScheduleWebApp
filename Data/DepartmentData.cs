using Core;
using Data.Common;

namespace Data
{
    public class DepartmentData : WithContactData,INamedEntity
    {
        public string name { get; set; }
    }
}
