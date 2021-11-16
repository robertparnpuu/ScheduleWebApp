using Data.Common;
using System;

namespace Data
{
    public class PersonData : BaseEntityData 
    {
        public string firstName { get; set; }
        public string lastName {  get; set; }
        public string roleAssignmentId {  get; set; }
        public string idCode { get; set; }
        public DateTime dateOfBirth { get; set;  }
        public string partyContactId { get; set; }
        public string contactId { get; set; }
        public string addressId { get; set; }
    }
}
