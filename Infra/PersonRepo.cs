using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class PersonRepo : PagedRepo<PersonData, Person>, IPersonRepo
    {
        public PersonRepo(ApplicationDbContext c) : base(c, c?.Persons) { }

        public override Person ToEntity(PersonData d) => new(d);
        public override PersonData ToData(Person e) => e?.Data ?? new PersonData();
    }
}
