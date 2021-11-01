using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using Infra.Initializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Initializer
{
    [TestClass]
    public class DbInitializerTests 
    {
        protected internal ApplicationDbContext TestDb;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb").Options;
            TestDb = new ApplicationDbContext(options);
            TestDb.RemoveRange(TestDb.Persons);
            TestDb.RemoveRange(TestDb.Addresses);
            TestDb.RemoveRange(TestDb.Contacts);
        }

        [TestMethod]
        public void InitializeTest()
        {
            DbInitializer.Initialize(TestDb);
            Assert.AreEqual(4, TestDb.Persons.Count());
            Assert.AreEqual(2, TestDb.Addresses.Count());
            Assert.AreEqual(3, TestDb.Contacts.Count());
        }
    }
}
