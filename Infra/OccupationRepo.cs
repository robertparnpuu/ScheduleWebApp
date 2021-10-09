using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
   public class OccupationRepo: IOccupationRepo
   {
        public readonly DbSet<OccupationData> dbSet;
        public readonly DbContext db;

        public OccupationRepo(ApplicationDbContext c)
        {
            db = c;
            dbSet = c?.Occupations;
        }

        protected internal Task<List<OccupationData>> getDataAsync() => dbSet.AsNoTracking().ToListAsync();

        public async Task<List<Occupation>> GetEntityAsync() => (await getDataAsync()).Select(ToEntity).ToList();

        protected internal Occupation ToEntity(OccupationData o) => new Occupation(o);

        public async Task<Occupation> GetAsync(string id)
        {
            throw new System.NotImplementedException();
            //    if (id is null) return null;
            //    if (dbSet is null) return null;
            //    return await dbSet.AsNoTracking().FirstOrDefaultAsync(r => r.id == id);
        }

        public Task<bool> DeleteAsync(Occupation obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddAsync(Occupation obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Occupation obj)
        {
            throw new System.NotImplementedException();
        }

        public Occupation Get(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
