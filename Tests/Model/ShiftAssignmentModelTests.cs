using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] 
    public class ShiftAssignmentModelTests : ViewedModelTests<ShiftAssignment, ShiftAssignmentView>
    {
        private class TestShiftAssignmentRepo : TestRepo<ShiftAssignment>, IShiftAssignmentRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestShiftAssignmentRepo();
            pageModel = new ShiftAssignmentModel((IShiftAssignmentRepo) mockRepo, null);
        }
    }
}