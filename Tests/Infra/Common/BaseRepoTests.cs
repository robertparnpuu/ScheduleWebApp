using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Data.Common;
using Domain.Common;
using Infra;
using Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable All

namespace Tests.Infra
{
    [TestClass]
    public class BaseRepoTests<TRepo, TData, TEntity>
    where TRepo : BaseRepo<TData, TEntity>
    where TData : BaseEntityData, new()
    where TEntity : BaseEntity<TData>, new()
    {
        public TRepo mockRepo;
        public TEntity entity;
        public TData data;

        private dynamic CreateInstance<T>(dynamic input) => (T)Activator.CreateInstance(typeof(T), input);

        protected TRepo CreateObject()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb").Options;
            var c = new ApplicationDbContext(options);
            return CreateInstance<TRepo>(c);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = CreateObject();
            data = GetRandom.ObjectOf<TData>();
            entity = CreateInstance<TEntity>(data);
            mockRepo.dbSet.RemoveRange(mockRepo.dbSet);
            mockRepo.db.SaveChanges();
        }
        [TestMethod]
        public void CanCreateEntity()
            => Assert.IsInstanceOfType(new TEntity(), typeof(TEntity));
        [TestMethod]
        public void CanCreateData()
            => Assert.IsInstanceOfType(new TData(), typeof(TData));

        [TestMethod]
        public async Task AddAsyncTest()
        {
            var expected = ToData(entity);
            Assert.IsTrue(await mockRepo.AddAsync(entity));
            ArePropertiesEqual(expected, entity.Data);
        }
        [TestMethod]
        public async Task UpdateAsyncTest()
        {
            await mockRepo.dbSet.AddAsync(data);
            await mockRepo.db.SaveChangesAsync();
            var o = await mockRepo.GetEntityAsync(data.id);
            ArePropertiesEqual(data, o.Data);

            var newObj = GetRandom.ObjectOf<TData>();
            Copy.Members(newObj, data, "id");

            await mockRepo.UpdateAsync(data);

            ArePropertiesEqual(data, newObj, "id");
        }
        [TestMethod]
        public async Task DeleteAsyncTest()
        {
            await mockRepo.dbSet.AddAsync(ToData(entity));
            await mockRepo.db.SaveChangesAsync();
            var o = await mockRepo.GetEntityAsync(data.id);
            ArePropertiesEqual(data, o.Data);

            await mockRepo.DeleteAsync(data.id);

            o = await mockRepo.GetEntityAsync(entity.id);
            ArePropertiesNotEqual(data, o.Data);
        }

        [TestMethod]
        public async Task GetEntityAsyncTest()
        {
            Assert.IsTrue(await mockRepo.AddAsync(entity));
            ArePropertiesEqual(ToData(entity), ToData(await mockRepo.GetEntityAsync(entity.id)));
        }


        [TestMethod]
        public virtual async Task GetEntityListAsyncTest()
        {
            var l = await mockRepo.GetEntityListAsync();
            Assert.AreEqual(0, l.Count);
            var count = GetRandom.UInt8(10, 20);
            for (var i = 1; i <= count; i++)
                await mockRepo.dbSet.AddAsync(GetRandom.ObjectOf<TData>());
            await mockRepo.db.SaveChangesAsync();
            l = await mockRepo.GetEntityListAsync();
            Assert.AreEqual(count, l.Count);
        }

        protected static void ArePropertiesEqual<T>(T expected, T actual, params string[] exceptProperties)
        {
            foreach (var p in typeof(T).GetProperties())
            {
                var expectedValue = p.GetValue(expected);
                var actualValue = p.GetValue(actual);
                if (exceptProperties.Contains(p.Name)) Assert.AreNotEqual(expectedValue, actualValue);
                else Assert.AreEqual(expectedValue, actualValue);
            }
        }
        protected static void ArePropertiesNotEqual<T>(T expected, T actual, params string[] exceptProperties)
        {
            foreach (var p in typeof(T).GetProperties())
            {
                var expectedValue = p.GetValue(expected);
                var actualValue = p.GetValue(actual);
                if (exceptProperties.Contains(p.Name)) Assert.AreEqual(expectedValue, actualValue);
                else Assert.AreNotEqual(expectedValue, actualValue);
            }
        }
        public TData ToData(TEntity e) => e?.Data ?? new TData();
        //public TEntity ToEntity(TData d) => new(d);
        public TEntity ToEntity(TData d) => CreateInstance<TEntity>(d);
        [TestMethod]
        public void ToEntityTest()
        {
            TData a = GetRandom.ObjectOf<TData>();
            var b = ToEntity(a);
            ArePropertiesEqual(a, b.Data);
            Assert.IsInstanceOfType(b, typeof(TEntity));
        }
    }
}
