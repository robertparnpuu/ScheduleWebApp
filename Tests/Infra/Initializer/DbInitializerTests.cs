using System.Linq;
using Aids;
using Data;
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
            TestDb.RemoveRange(TestDb.Addresses);
            TestDb.RemoveRange(TestDb.Contacts);
            TestDb.RemoveRange(TestDb.Contracts);
            TestDb.RemoveRange(TestDb.Departments);
            TestDb.RemoveRange(TestDb.Locations);
            TestDb.RemoveRange(TestDb.Occupations);
            TestDb.RemoveRange(TestDb.PartyContacts);
            TestDb.RemoveRange(TestDb.Persons);
            TestDb.RemoveRange(TestDb.Requirements);
            TestDb.RemoveRange(TestDb.ShiftAssignments);
            TestDb.RemoveRange(TestDb.StandardShifts);
            TestDb.RemoveRange(TestDb.WeekDays);
            TestDb.SaveChanges();
        }

        [TestMethod]
        public void InitializeNewDbTrueTest()
        {
            DbInitializer.Initialize(TestDb,true);
            Assert.AreEqual(11, TestDb.Addresses.Count());
            Assert.AreEqual(11, TestDb.Contacts.Count());
            Assert.AreEqual(5, TestDb.Contracts.Count());
            Assert.AreEqual(3, TestDb.Departments.Count());
            Assert.AreEqual(3, TestDb.Locations.Count());
            Assert.AreEqual(4, TestDb.Occupations.Count());
            Assert.AreEqual(11, TestDb.PartyContacts.Count());
            Assert.AreEqual(5, TestDb.Persons.Count());
            Assert.AreEqual(7, TestDb.Requirements.Count());
            Assert.AreEqual(14, TestDb.ShiftAssignments.Count());
            Assert.AreEqual(3, TestDb.StandardShifts.Count());
            Assert.AreEqual(7, TestDb.WeekDays.Count());
        }
        [TestMethod]
        public void InitializeNewDbFalseTest()
        {
            var count = GetRandom.UInt8(5, 10);
            for (var i = 1; i <= count; i++)
               AddOneToAllTables();
            DbInitializer.Initialize(TestDb, false);
            Assert.AreEqual(count, TestDb.Addresses.Count());
            Assert.AreEqual(count, TestDb.Contacts.Count());
            Assert.AreEqual(count, TestDb.Contracts.Count());
            Assert.AreEqual(count, TestDb.Departments.Count());
            Assert.AreEqual(count, TestDb.Locations.Count());
            Assert.AreEqual(count, TestDb.Occupations.Count());
            Assert.AreEqual(count, TestDb.PartyContacts.Count());
            Assert.AreEqual(count, TestDb.Persons.Count());
            Assert.AreEqual(count, TestDb.Requirements.Count());
            Assert.AreEqual(count, TestDb.ShiftAssignments.Count());
            Assert.AreEqual(count, TestDb.StandardShifts.Count());
            Assert.AreEqual(count, TestDb.WeekDays.Count());
        }

        private void AddOneToAllTables()
        {
            TestDb.Addresses.Add(GetRandom.ObjectOf<AddressData>());
            TestDb.Contacts.Add(GetRandom.ObjectOf<ContactData>());
            TestDb.Contracts.Add(GetRandom.ObjectOf<ContractData>());
            TestDb.Departments.Add(GetRandom.ObjectOf<DepartmentData>());
            TestDb.Locations.Add(GetRandom.ObjectOf<LocationData>());
            TestDb.Occupations.Add(GetRandom.ObjectOf<OccupationData>());
            TestDb.PartyContacts.Add(GetRandom.ObjectOf<PartyContactData>());
            TestDb.Persons.Add(GetRandom.ObjectOf<PersonData>());
            TestDb.Requirements.Add(GetRandom.ObjectOf<RequirementData>());
            TestDb.ShiftAssignments.Add(GetRandom.ObjectOf<ShiftAssignmentData>());
            TestDb.StandardShifts.Add(GetRandom.ObjectOf<StandardShiftData>());
            TestDb.WeekDays.Add(GetRandom.ObjectOf<WeekDayData>());
        }
    }
}
