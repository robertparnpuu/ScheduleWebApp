using System;
using Domain;
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
        public void PartyContactIdTest() => IsProperty<string>(nameof(obj.partyContactId));
        [TestMethod]
        public void DateOfBirthTest() => IsProperty<DateTime>(nameof(obj.dateOfBirth));
        [TestMethod]
        public void FullContactTest() => IsProperty<string>(nameof(obj.fullContact));
        [TestMethod]
        public void FullAddressTest() => IsProperty<string>(nameof(obj.fullAddress));
    }
}