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
            aData= GetRandom.ObjectOf<AddressData>();
            aEntity = new Address(aData);
        }
        [TestMethod]
        public async Task AddAsyncTest()
        {
            var expected = ToData(aEntity);
            await mockRepo.AddAsync(aEntity);
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
