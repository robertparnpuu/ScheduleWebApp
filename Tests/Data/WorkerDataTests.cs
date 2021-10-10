﻿using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Data.Common;

namespace Tests.Data
{
    [TestClass]
    public class WorkerDataTests:IdBaseDataTests<WorkerData,PersonData>
    {
        [TestMethod]
        public void PersonTest() => IsProperty<string>(nameof(obj.personId));
        [TestMethod]
        public void RoleAssignmentTest() => IsProperty<string>(nameof(obj.roleAssignmentId));
        [TestMethod]
        public void OccupationAssignmentTest() => IsProperty<string>(nameof(obj.occupationAssignmentId));
        [TestMethod]
        public void DepartmentTest() => IsProperty<string>(nameof(obj.departmentId));
    }
}
