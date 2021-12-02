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
        private class TestShiftAssignmentRepo : TestRepo<ShiftAssignment>, IShiftAssignmentRepo
        {
            public Task<List<ShiftAssignment>> GetEntityListAsync(DateTime dt1, DateTime dt2)
            {
                throw new NotImplementedException();
            }
        }
        private class TestStandardShiftRepo : TestRepo<StandardShift>, IStandardShiftRepo { }
        private class TestContractRepo : TestRepo<Contract>, IContractRepo { }
        
        protected TestRepo<StandardShift> ssRepo;
        protected TestRepo<Contract> cRepo;

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestShiftAssignmentRepo();
            ssRepo = new TestStandardShiftRepo();
            cRepo = new TestContractRepo();
            pageModel = new ScheduleModel((IShiftAssignmentRepo)mockRepo, (IStandardShiftRepo) ssRepo, (IContractRepo) cRepo, null);
        }

    }
}
