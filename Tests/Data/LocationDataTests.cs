using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class LocationDataTests:NamedBaseTest<LocationData, NamedEntityData>
    {
        [TestMethod]
        public void ContactTest() => IsProperty<string>(nameof(obj.contactId));
    }
}
