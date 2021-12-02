using Core;

namespace Data.Common
{
    public class WithContactData: BaseEntityData,IWithContact
    {
        public string partyContactId { get; set; }
    }
}
