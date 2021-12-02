using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] 
    public class ShiftAssignmentModelTests : ViewedModelTests<ShiftAssignment, ShiftAssignmentView>
    {
        //Ebavalik kui kasutame peamiselt ikka ScheduleModelit?
        private class TestShiftAssignmentRepo : TestRepo<ShiftAssignment>, IShiftAssignmentRepo
        {
            public DateTime startTime { get; set; }
            public DateTime endTime { get; set; }
        }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestShiftAssignmentRepo();
            pageModel = new ShiftAssignmentModel((IShiftAssignmentRepo) mockRepo, null);
        }
    }
}