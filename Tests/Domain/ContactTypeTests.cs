using Data;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Common;

namespace Tests.Domain
{
    [TestClass]
    public class ContactTypeEntityTests : BaseEntityTests<ContactType, ContactTypeData>
    {

        [TestMethod]
        public void AddressIdTest() => isReadOnlyProperty(obj.Data.name);
    }
}