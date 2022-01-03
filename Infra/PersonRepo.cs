using System.Linq;
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
        protected internal override IQueryable<PersonData> applyFilters(IQueryable<PersonData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
            x => x.firstName.Contains(SearchString) || 
                 x.lastName.Contains(SearchString) ||
                 x.idCode.Contains(SearchString));
        }
    }
}
