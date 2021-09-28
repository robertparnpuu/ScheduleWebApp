using Data.Common;
using System;

namespace Data
{
    public class PersonData : BaseEntityData 
    {
        public string firstName { get; set; }
        public string lastName {  get; set; }
        public string idCode { get; set; }
        //Todo: Debate country specifier need
        public DateTime dateOfBirth { get; set;  }
        public string contactId { get; set; }
    }
}
