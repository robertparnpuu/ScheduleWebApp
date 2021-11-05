using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class ContactEntityTests : BaseEntityTests<Contact, ContactData>
    {

        [TestMethod]
        public void PartyContactIdTest() => isReadOnlyProperty(obj.Data.partyContactId);
        [TestMethod]
        public void EmailTest() => isReadOnlyProperty(obj.Data.email);
        [TestMethod]
        public void PhoneNumberTest() => isReadOnlyProperty(obj.Data.phoneNumber);
    }
}
