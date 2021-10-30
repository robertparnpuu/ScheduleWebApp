using System;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class PersonViewTests : BaseViewTests<PersonView>
    {
        [TestMethod]
        public void FirstNameTest() => IsProperty<string>(nameof(obj.firstName));
        [TestMethod]
        public void LastNameTest() => IsProperty<string>(nameof(obj.lastName));
        [TestMethod]
        public void IdCodeTest() => IsProperty<string>(nameof(obj.idCode));
        [TestMethod]
        public void ContactIdTest() => IsProperty<string>(nameof(obj.contactId));
        [TestMethod]
        public void FullContactTest() => IsProperty<string>(nameof(obj.fullContact));
        [TestMethod]
        public void DateOfBirthTest() => IsProperty<DateTime>(nameof(obj.dateOfBirth));
    }
}