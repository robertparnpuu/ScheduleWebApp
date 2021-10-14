using Core;
using Data.Common;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;

namespace Infra.Common
{
    public abstract class BaseRepo<TData, TEntity> : BaseRepo<TData>, IRepo<TEntity>
    where TData : BaseEntityData, IBaseEntityData, new()
    {
        protected BaseRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s) { }

        public abstract TEntity ToEntity(TData d);
        public abstract TData ToData(TEntity e);

        public new async Task<List<TEntity>> GetEntityListAsync() => (await base.GetEntityListAsync()).Select(ToEntity).ToList();
        public new async Task<TEntity> GetEntityAsync(string id)=>ToEntity(await base.GetEntityAsync(id));
        public async Task<bool> AddAsync(TEntity obj) => await AddAsync(ToData(obj));
        public async Task<bool> UpdateAsync(TEntity obj) => await UpdateAsync(ToData(obj));
    }

    public abstract class BaseRepo<TData>
    where TData: BaseEntityData,IBaseEntityData,new()
    {
        public readonly DbSet<TData> dbSet;
        public readonly DbContext db;

        protected BaseRepo(DbContext c, DbSet<TData> d)
        {
            db = c;
            dbSet = d;
        }

        public async Task<List<TData>> GetEntityListAsync()=> (await GetDataListAsync()).ToList();
        protected internal Task<List<TData>> GetDataListAsync() => dbSet.AsNoTracking().ToListAsync();

        public async Task<TData> GetEntityAsync(string id)=> (await GetDataAsync(id));
        protected internal async Task<TData> GetDataAsync(string id)
        {
            if (id is null) return null;
            if (dbSet is null) return null;
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(r => r.id == id);
        }

        public async Task<bool> DeleteAsync(string id)=> await DeleteFromDatabase(id);
        protected internal async Task<bool> DeleteFromDatabase(string id)
        {
            var o = await dbSet.FindAsync(id);
            var isOk = IsEntityOk(o);
            if (isOk) dbSet.Remove(o);
            await db.SaveChangesAsync();
            return isOk;
        }
        private bool IsEntityOk(object obj)
        {
            if (obj is null) return false;
            return dbSet is not null;
        }
        
        public async Task<bool> AddAsync(TData obj)
        {
            if (obj is null) return false;
            if (dbSet is null) return false;
            return await AddToDatabase(obj);
        }
        protected internal async Task<bool> AddToDatabase(TData obj)
        {
            if (!IsEntityOk(obj)) return false;
            await dbSet.AddAsync(obj);
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(TData obj)
        {
            if (obj is null) return false;
            if (dbSet is null) return false;
            return await UpdateInDatabase(obj);
        }
        protected internal async Task<bool> UpdateInDatabase(TData obj)
        {
            var o = await dbSet.FindAsync(obj.id);
            Copy.Members(obj, o);
            var isOk = IsEntityOk(o);
            if (isOk) dbSet.Update(o);
            await db.SaveChangesAsync();
            return isOk;
        }
    }

}


