using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Data;
using Domain;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable All

namespace Tests.Infra
{
    [TestClass]
    public class AddressRepoTests
    {
        protected AddressRepo CreateObject()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb").Options;
            var c = new ApplicationDbContext(options);
            return new AddressRepo(c);
        }

        public AddressRepo mockRepo;
        public Address aEntity;
        public AddressData aData;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = CreateObject();
            aData= GetRandom.ObjectOf<AddressData>();
            aEntity = new Address(aData);
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

        [TestMethod]
        public async Task GetEntityListAsyncTest3()
        {
            List<Address> entities = new List<Address>();
            int r = 4;
            for (int i = 0; i < r; i++)
            {
                var a = new Address(GetRandom.ObjectOf<AddressData>());
                entities.Add(a);
                Assert.IsTrue(await mockRepo.AddAsync(a));
            }
            var addresses = await mockRepo.GetEntityListAsync();
            for (int i = 0; i < entities.Count; i++)
            {
                ArePropertiesEqual(ToData(entities[i]), ToData(addresses[i]));
            }
            Assert.AreEqual(r, addresses.Count());
        }

        [TestMethod]
        public async Task GetEntityListAsyncTest2()
        {
            await mockRepo.AddAsync(aEntity);
            Address aEntity2 = new Address(GetRandom.ObjectOf<AddressData>());
            await mockRepo.AddAsync(aEntity2);
            List<Address> addresses = await mockRepo.GetEntityListAsync();
            ArePropertiesEqual(ToData(aEntity), addresses[1].Data);
            ArePropertiesEqual(ToData(aEntity2), addresses[0].Data);
            Assert.AreEqual(2, addresses.Count);
        }

        [TestMethod]
        public async Task GetEntityListAsyncTest()
        {
            var l = await mockRepo.GetEntityListAsync();
            Assert.AreEqual(0, l.Count);
            var count = GetRandom.UInt8(10, 20);
            for (var i = 1; i <= count; i++)
                await mockRepo.dbSet.AddAsync(GetRandom.ObjectOf<AddressData>());
            await mockRepo.db.SaveChangesAsync();
            l = await mockRepo.GetEntityListAsync();
            Assert.AreEqual( count, l.Count);
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
        public AddressData ToData(Address e) => e?.Data ?? new AddressData();
        public  Address ToEntity(AddressData d) => new(d);

        [TestMethod]
        public void ToEntityTest()
        {
            AddressData a = GetRandom.ObjectOf<AddressData>();
            var b = ToEntity(a);
            ArePropertiesEqual(a,b.Data);
            Assert.IsInstanceOfType(b,typeof(Address));
        }

    }
}
