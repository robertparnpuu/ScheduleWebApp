using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class PartyContactRepo : PagedRepo<PartyContactData, PartyContact>, IPartyContactRepo
    {
        public PartyContactRepo(ApplicationDbContext c) : base(c, c?.PartyContacts) { }

        public override PartyContact ToEntity(PartyContactData d) => new(d);
        public override PartyContactData ToData(PartyContact e) => e?.Data ?? new PartyContactData();

    }
}