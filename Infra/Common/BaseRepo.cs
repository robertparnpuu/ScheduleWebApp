using Core;
using Data.Common;
using Domain.Common;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Common
{
    public abstract class BaseRepo<TData, TEntity> : BaseRepo<TData>, IRepo<TEntity>
    where TData : BaseEntityData, IBaseEntityData, new()
    {
        public abstract TEntity ToEntity(TData d);
        public abstract TData ToData(TEntity e);

        protected BaseRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s) { }
        
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

        protected internal Task<List<TData>> GetDataListAsync() => dbSet.AsNoTracking().ToListAsync();
        public async Task<List<TData>> GetEntityListAsync()=> (await GetDataListAsync()).ToList();
       
        public async Task<TData> GetEntityAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> AddAsync(TData obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(TData obj)
        {
            throw new System.NotImplementedException();
        }
    }

}


