using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Repos;
using Facade;
using Tests.Model.Common;
using PageModels;

namespace Tests.Model
{
    [TestClass]
    public class ScheduleModelTests : BaseModelTests<ShiftAssignment, ShiftAssignmentView>
    {
        private class TestShiftAssignmentRepo : TestRepo<ShiftAssignment>, IShiftAssignmentRepo { }
        private class TestStandardShiftRepo : TestRepo<StandardShift>, IStandardShiftRepo { }
        private class TestPersonRepo : TestRepo<Person>, IPersonRepo { }
        
        protected TestRepo<StandardShift> ssRepo;
        protected TestRepo<Person> pRepo;

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestShiftAssignmentRepo();
            ssRepo = new TestStandardShiftRepo();
            pRepo = new TestPersonRepo();
            pageModel = new ScheduleModel((IShiftAssignmentRepo)mockRepo, (IStandardShiftRepo) ssRepo, (IPersonRepo) pRepo, null);
        }

    }
}
