//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Core;
//using Data.Common;
//using Domain.Repos;
//using Microsoft.EntityFrameworkCore;

//namespace Infra.Common
//{
//    public abstract class BaseRepo<TEntity, TData> : BaseRepo<TData>, IRepo<TEntity>
//    where TData : BaseEntityData, IBaseEntity, new()
//    {
//        public abstract TEntity ToEntity(TData d);
//        public abstract TData ToData(TEntity e);
//        protected BaseRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s) { }
//        public new TEntity EntityInDb => ToEntity(base.EntityInDb);
//        public new async Task<List<TEntity>> GetAsync() => (await base.GetAsync()).Select(ToEntity).ToList();
//        public new async Task<TEntity> GetAsync(string id) => ToEntity(await base.GetAsync(id));
//        public virtual async Task<bool> DeleteAsync(TEntity e) => await DeleteAsync(ToData(e));
//        public virtual async Task<bool> AddAsync(TEntity e) => await AddAsync(ToData(e));

//        public virtual async Task<bool> UpdateAsync(TEntity e) => await UpdateAsync(ToData(e));
//        public new TEntity Get(string id) => ToEntity(base.Get(id));
//        //public List<TEntity> Get() => GetDropDownList().Select(ToEntity).ToList();
//    }
//    public abstract class BaseRepo<TData> where TData : BaseEntityData, IBaseEntity, new()
//    {
//        private DbSet<TData> dbSet;
//        private DbContext db;
//        public TData EntityInDb { get; protected set; }
//        //public string ErrorMessage { get; protected set; }

//        protected BaseRepo(DbContext c = null, DbSet<TData> s = null)
//        {
//            dbSet = s;
//            db = c;
//        }

//        public Task<List<TData>> GetAsync()
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<TData> GetAsync(string id)
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<bool> DeleteAsync(TData obj)
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<bool> AddAsync(TData obj)
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<bool> UpdateAsync(TData obj)
//        {
//            throw new System.NotImplementedException();
//        }

//        public TData Get(string id)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
