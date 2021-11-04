using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class ContactTypeRepo : BaseRepo<ContactTypeData, ContactType>, IContactTypeRepo
    {
        public ContactTypeRepo(ApplicationDbContext c) : base(c, c?.ContactTypes) { }

        public override ContactType ToEntity(ContactTypeData d) => new(d);
        public override ContactTypeData ToData(ContactType e) => e?.Data ?? new ContactTypeData();

    }
}