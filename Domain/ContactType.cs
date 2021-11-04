using Data;
using Domain.Common;

namespace Domain
{
    public class ContactType : BaseEntity<ContactTypeData>
    {
        public ContactType() : this(null) { }

        public ContactType(ContactTypeData d) : base(d)
        {
        }

        public string name => Data?.name ?? "-";
    }
}