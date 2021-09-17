using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class PersonData : BaseEntityData 
    {
        public string firstName { get; set; }
        public string lastName {  get; set; }
        public string idCode { get; set; }
        //Todo: Debate country specifier need
        public DateTime dateOfBirth { get; set;  }
        public int contactId { get; set; }
    }
}
