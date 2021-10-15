using Data;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra
{
    public class WorkerRepo : BaseRepo<WorkerData, Worker>, IWorkerRepo
    {
        public WorkerRepo(ApplicationDbContext c) : base(c, c?.Workers) { }

        public override Worker ToEntity(WorkerData d) => new(d);
        public override WorkerData ToData(Worker e) => e?.Data ?? new WorkerData();
    }
}
