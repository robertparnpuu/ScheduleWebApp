using System;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class RoleAssignmentViewTests : BaseViewTests<RoleAssignmentView>
    {
        [TestMethod]
        public void PersonIdTest() => IsProperty<string>(nameof(obj.personId));
        [TestMethod]
        public void RoleIdTest() => IsProperty<string>(nameof(obj.roleId));
        [TestMethod]
        public void PersonNameTest() => IsProperty<string>(nameof(obj.personName));
        [TestMethod]
        public void RoleNameTest() => IsProperty<string>(nameof(obj.roleName));
        [TestMethod]
        public void ValidFromTest() => IsProperty<DateTime>(nameof(obj.validFrom));
        [TestMethod]
        public void ValidToTest() => IsProperty<DateTime>(nameof(obj.validTo));
    }
}
