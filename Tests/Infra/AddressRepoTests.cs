﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Data;
using Domain;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            aEntity = new Address(GetRandom.ObjectOf<AddressData>());
        }
        [TestMethod]
        public async Task AddAsyncTest()
        {
            var expected = ToData(aEntity);
            Assert.IsTrue(await mockRepo.AddAsync(aEntity));
            ArePropertiesEqual(expected, aEntity.Data);
        }

        [TestMethod]
        public async Task GetEntityAsyncTest()
        {
            Assert.IsTrue(await mockRepo.AddAsync(aEntity));
            ArePropertiesEqual(ToData(aEntity), ToData(await mockRepo.GetEntityAsync(aEntity.id)));
        }

        //[TestMethod]
        //public async Task GetEntityListAsyncTest()
        //{
        //    List<Address> entities = new List<Address>();
        //    List<Address> addresses = new List<Address>();
        //    int r = 4;
        //    for (int i = 0; i < r; i++)
        //    {
        //        var a = new Address(GetRandom.ObjectOf<AddressData>());
        //        entities.Add(a);
        //        Assert.IsTrue(await mockRepo.AddAsync(a));
        //    }
        //    addresses = await mockRepo.GetEntityListAsync();
        //    addresses.OrderBy(x => x.Data.id);
        //    entities.OrderBy(x => x.Data.id);
        //    for (int i = 0; i < entities.Count; i++)
        //    {
        //        ArePropertiesEqual(ToData(entities[i]),ToData(addresses[i]));
        //    }
        //    Assert.AreEqual(r, addresses.Count());
        //}

        [TestMethod]
        public async Task GetEntityListAsyncTest()
        {
            await mockRepo.AddAsync(aEntity);
            Address aEntity2 = new Address(GetRandom.ObjectOf<AddressData>());
            await mockRepo.AddAsync(aEntity2);
            List<Address> addresses = await mockRepo.GetEntityListAsync();
            ArePropertiesEqual(ToData(aEntity), addresses[0].Data);
            ArePropertiesEqual(ToData(aEntity2), addresses[1].Data);
            Assert.AreEqual(2, addresses.Count);
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
        public AddressData ToData(Address e) => e?.Data ?? new AddressData();
        public  Address ToEntity(AddressData d) => new(d);
    }
}
