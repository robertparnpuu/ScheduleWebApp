using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class WeekDayRepo : PagedRepo<WeekDayData, WeekDay>, IWeekDayRepo
    {
        public WeekDayRepo(ApplicationDbContext c) : base(c, c?.WeekDays) { }

        public override WeekDay ToEntity(WeekDayData d) => new(d);
        public override WeekDayData ToData(WeekDay e) => e?.Data ?? new WeekDayData();
    }
}
