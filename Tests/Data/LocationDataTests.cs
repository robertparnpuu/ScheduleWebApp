using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Data.Common;

namespace Tests.Data
{
    [TestClass]
    public class LocationDataTests : WithContactDataTests<LocationData, WithContactData>
    {
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));
    }
}
