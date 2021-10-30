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
            Assert.IsInstanceOfType(mockRepo, typeof(AddressRepo));
            Assert.IsInstanceOfType(aEntity, typeof(Address));
            var expected = ToData(aEntity);
            await mockRepo.AddAsync(aEntity);
            ArePropertiesEqual(expected, aEntity.Data);
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
