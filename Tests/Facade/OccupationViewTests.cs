using Microsoft.VisualStudio.TestTools.UnitTesting;

using Facade;
using Tests.Facade.Common;

namespace Tests.Facade
{
    [TestClass]
    public class OccupationViewTests : BaseViewTests<OccupationView>
    {
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));
    }
}
