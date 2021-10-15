using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class ContactRepo : BaseRepo<ContactData, Contact>, IContactRepo
    {
        public ContactRepo(ApplicationDbContext c) : base(c, c?.Contacts) { }

        public override Contact ToEntity(ContactData d) => new(d);
        public override ContactData ToData(Contact e) => e?.Data ?? new ContactData();
    }
}
