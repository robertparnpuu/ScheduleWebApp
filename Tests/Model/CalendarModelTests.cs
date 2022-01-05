using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moq;
using Tests.Model.Common;
using PageModels;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;


namespace Tests.Model
{
    [TestClass]
    public class CalendarModelTests
    {
        private class TestShiftAssignmentRepo : TestRepo<ShiftAssignment>, IShiftAssignmentRepo
        {
            public DateTime startTime { get; set; }
            public DateTime endTime { get; set; }
        }
        private  TestShiftAssignmentRepo _repo;
        private  ApplicationDbContext _testDb;
        private CalendarModel _pageModel;

        [TestInitialize]
        public void TestInitialize()
        {
            _repo = new TestShiftAssignmentRepo();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb").Options;
            _testDb = new ApplicationDbContext(options); ;
            _pageModel = new CalendarModel((IShiftAssignmentRepo) _repo, _testDb);
        }

        [TestMethod]
        public void OnGetIndexReturnsPageTest()
        {
            var result = _pageModel.OnGetIndexAsync();
            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
        }

        [TestMethod]
        public void ToCalendarViewTest()
        {
            var result =_pageModel.ToCalendarView(GetRandom.ObjectOf<ShiftAssignment>());
            Assert.IsInstanceOfType(result, typeof(CalendarView));
        }
    }
}
