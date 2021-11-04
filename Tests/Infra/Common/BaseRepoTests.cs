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
        public TEntity aEntity;
        public TData aData;

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
            aData = GetRandom.ObjectOf<TData>();
            //aEntity = new TEntity(aData);
            aEntity = CreateInstance<TEntity>(aData);
            mockRepo.dbSet.RemoveRange(mockRepo.dbSet);
            mockRepo.db.SaveChanges();
        }
        [TestMethod]
        public async Task AddAsyncTest()
        {
            var expected = ToData(aEntity);
            Assert.IsTrue(await mockRepo.AddAsync(aEntity));
            ArePropertiesEqual(expected, aEntity.Data);
        }
        [TestMethod]
        public async Task UpdateAsyncTest()
        {
            await mockRepo.dbSet.AddAsync(aData);
            await mockRepo.db.SaveChangesAsync();
            var o = await mockRepo.GetEntityAsync(aData.id);
            ArePropertiesEqual(aData, o.Data);

            var newObj = GetRandom.ObjectOf<TData>();
            Copy.Members(newObj, aData, "id");

            await mockRepo.UpdateAsync(aData);

            ArePropertiesEqual(aData, newObj, "id");
        }
        [TestMethod]
        public async Task DeleteAsyncTest()
        {
            await mockRepo.dbSet.AddAsync(ToData(aEntity));
            await mockRepo.db.SaveChangesAsync();
            var o = await mockRepo.GetEntityAsync(aData.id);
            ArePropertiesEqual(aData, o.Data);

            await mockRepo.DeleteAsync(aData.id);

            o = await mockRepo.GetEntityAsync(aEntity.id);
            ArePropertiesNotEqual(aData, o.Data);
        }

        [TestMethod]
        public async Task GetEntityAsyncTest()
        {
            Assert.IsTrue(await mockRepo.AddAsync(aEntity));
            ArePropertiesEqual(ToData(aEntity), ToData(await mockRepo.GetEntityAsync(aEntity.id)));
        }

        //[TestMethod]
        //public async Task GetEntityListAsyncTest2()
        //{
        //    await mockRepo.AddAsync(aEntity);
        //    //TEntity aEntity2 = new TEntity(GetRandom.ObjectOf<TData>());
        //    TEntity aEntity2 = CreateInstance<TEntity>(GetRandom.ObjectOf<TData>());
        //    await mockRepo.AddAsync(aEntity2);
        //    List<TEntity> addresses = await mockRepo.GetEntityListAsync();
        //    ArePropertiesEqual(ToData(aEntity), addresses[1].Data);
        //    ArePropertiesEqual(ToData(aEntity2), addresses[0].Data);
        //    Assert.AreEqual(2, addresses.Count);
        //}

        [TestMethod]
        public async Task GetEntityListAsyncTest()
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
