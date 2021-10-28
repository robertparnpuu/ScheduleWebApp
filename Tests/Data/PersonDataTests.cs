using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Data.Common;

namespace Tests.Data
{
    [TestClass]
    public class PersonDataTests : IdBaseDataTests<PersonData, BaseEntityData>
    {
        [TestMethod]
        public void FirstNameTest() => IsProperty<string>(nameof(obj.firstName));
        [TestMethod]
        public void LastNameTest() => IsProperty<string>(nameof(obj.lastName));
        [TestMethod]
        public void IdCodeTest() => IsProperty<string>(nameof(obj.idCode));
        [TestMethod]
        public void DateOfBirthTest() => IsProperty<DateTime>(nameof(obj.dateOfBirth));
        [TestMethod]
        public void ContactTest() => IsProperty<string>(nameof(obj.contactId));
        [TestMethod]
        public void RoleAssignmentIdTest() => IsProperty<string>(nameof(obj.roleAssignmentId));
    }
}
