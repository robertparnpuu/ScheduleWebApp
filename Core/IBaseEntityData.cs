using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids;

namespace Core
{
    public interface IBaseEntityData: IBaseEntity
    {
        public string id { get; set; }
    }
}
