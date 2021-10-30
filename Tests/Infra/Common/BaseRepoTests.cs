//using Aids;
//using Core;
//using Data.Common;
//using Domain.Common;
//using Infra;
//using Infra.Common;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Tests.Infra.Common
//{
//    public abstract class BaseRepoTests<TRepo,TData,TEntity>
//    where TRepo:BaseRepo<TData,TEntity>
//    where TData : BaseEntityData, IBaseEntityData, new()
//    where TEntity : BaseEntity<TData>, IBaseEntity, new()
//    {
//        protected TEntity obj;
//        protected TRepo mockRepo;
//        protected abstract TRepo CreateRepo(ApplicationDbContext c);

//        protected BaseRepo<TData,TEntity> CreateObject()
//        {
//            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
//            .UseInMemoryDatabase("TestDb").Options;
//            var c = new ApplicationDbContext(options);
//            return new TestRepo<TData,TEntity>(c);
//        }
//        [TestInitialize]
//        public void TestInitialize()
//        {
//            obj = CreateEntityObject();
//            mockRepo = CreateObject();
//        }
//        protected virtual TEntity CreateEntityObject() => GetRandom.ObjectOf<TEntity>();
//    }
//    public class TestRepo<TData, TEntity> : BaseRepo<TData,TEntity>
//    where TData : BaseEntityData, IBaseEntityData, new()
//    where TEntity : BaseEntity<TData>, IBaseEntity, new()
//    {
//        public TestRepo(ApplicationDbContext c = null)
//        : base(c, null)
//        {
//        }

//        public override TEntity ToEntity(TData d) => new();
//        public override TData ToData(TEntity e) => e.Data;
//    }
    
//}
