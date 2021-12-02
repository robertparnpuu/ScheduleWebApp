using System;
using System.Threading.Tasks;
using Data;
using Domain;
using Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra
{
    [TestClass]
    public class ShiftAssignmentRepoTests : BaseRepoTests<ShiftAssignmentRepo, ShiftAssignmentData, ShiftAssignment>
    {
        [TestMethod]
        public override async Task GetEntityListAsyncTest()
        {
            mockRepo.startTime = DateTime.MinValue;
            mockRepo.endTime = DateTime.MaxValue;
            base.GetEntityListAsyncTest();
        }
    }
}
