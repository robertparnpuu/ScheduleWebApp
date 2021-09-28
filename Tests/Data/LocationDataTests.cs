using Core;
using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Data.Common;

namespace Tests.Data
{
    [TestClass]
    public class LocationDataTests:BaseTests<LocationData, NamedEntityData>
    {
        [TestMethod]
        public void ContactTest() => IsProperty<string>(nameof(obj.contactId));
    }
}
