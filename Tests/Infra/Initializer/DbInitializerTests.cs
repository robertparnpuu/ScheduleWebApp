using System.Linq;
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
            TestDb.RemoveRange(TestDb.Departments);
            TestDb.RemoveRange(TestDb.Locations);
            TestDb.RemoveRange(TestDb.Contracts);
            TestDb.RemoveRange(TestDb.Occupations);
            TestDb.RemoveRange(TestDb.Requirements);
            TestDb.RemoveRange(TestDb.RoleAssignments);
            TestDb.RemoveRange(TestDb.Roles);
            TestDb.RemoveRange(TestDb.ShiftAssignments);
            TestDb.RemoveRange(TestDb.StandardShifts);
            TestDb.RemoveRange(TestDb.WeekDays);
        }

        [TestMethod]
        public void InitializeTest()
        {
            DbInitializer.Initialize(TestDb);
            Assert.AreEqual(4, TestDb.Persons.Count());
            Assert.AreEqual(2, TestDb.Addresses.Count());
            Assert.AreEqual(3, TestDb.Contacts.Count());
            Assert.AreEqual(0, TestDb.Departments.Count());
            Assert.AreEqual(0, TestDb.Locations.Count());
            Assert.AreEqual(0, TestDb.Contracts.Count());
            Assert.AreEqual(0, TestDb.Occupations.Count());
            Assert.AreEqual(0, TestDb.Requirements.Count());
            Assert.AreEqual(0, TestDb.RoleAssignments.Count());
            Assert.AreEqual(0, TestDb.Roles.Count());
            Assert.AreEqual(0, TestDb.ShiftAssignments.Count());
            Assert.AreEqual(0, TestDb.StandardShifts.Count());
            Assert.AreEqual(7, TestDb.WeekDays.Count());
        }
    }
}
