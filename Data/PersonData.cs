using Data.Common;
using System;

namespace Data
{
    public class PersonData : WithContactData 
    {
        public string firstName { get; set; }
        public string lastName {  get; set; }
        public string roleAssignmentId {  get; set; }
        public string idCode { get; set; }
        public DateTime dateOfBirth { get; set;  }
        //public string partyContactId { get; set; }
    }
}
