using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Data;
using Domain;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class OccupationRepo : IOccupationRepo
    {
        public readonly DbSet<OccupationData> dbSet;
        public readonly DbContext db;

        public OccupationRepo(ApplicationDbContext c)
        {
            db = c;
            dbSet = c?.Occupations;
        }

        protected internal Task<List<OccupationData>> GetDataListAsync() => dbSet.AsNoTracking().ToListAsync();

        public async Task<List<Occupation>> GetEntityListAsync() =>
        (await GetDataListAsync()).Select(ToEntity).ToList();

        protected internal Occupation ToEntity(OccupationData d) => new Occupation(d);
        protected internal OccupationData ToData(Occupation e) => e?.Data ?? new OccupationData();

        protected internal async Task<OccupationData> GetDataAsync(string id)
        {
            if (id is null) return null;
            if (dbSet is null) return null;
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(r => r.id == id);
        }

        public async Task<Occupation> GetEntityAsync(string id) => ToEntity(await GetDataAsync(id));

        public async Task<bool> DeleteAsync(string id) => await DeleteFromDatabase(id);
        
        protected internal async Task<bool> DeleteFromDatabase(string id)
        {
            var o = await dbSet.FindAsync(id);
            var isOk = IsEntityOk(o);
            if (isOk) dbSet.Remove(o);
            await db.SaveChangesAsync();
            return isOk;
        }

        public async Task<bool> AddAsync(Occupation obj)
        {
            if (obj is null) return false;
            if (dbSet is null) return false;
            return await AddToDatabase(ToData(obj));
        }


        protected internal async Task<bool> AddToDatabase(OccupationData obj)
        {
            if (!IsEntityOk(obj)) return false;
            await dbSet.AddAsync(obj);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Occupation obj)
        {
            if (obj is null) return false;
            if (dbSet is null) return false;
            return await UpdateInDatabase(ToData(obj));
        }

        protected internal async Task<bool> UpdateInDatabase(OccupationData obj)
        {
            var o = await dbSet.FindAsync(obj.id);
            Copy.Members(obj, o);
            var isOk = IsEntityOk(o);
            if (isOk) dbSet.Update(o);
            await db.SaveChangesAsync();
            return isOk;
        }

        public Occupation Get(string id)
        {
            throw new System.NotImplementedException();
        }

        private bool IsEntityOk(object obj)
        {
            if (obj is null) return false;
            if (dbSet is null) return false;
            return true;
        }
    }
}
