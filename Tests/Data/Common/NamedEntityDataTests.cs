using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Data.Common
{
    [TestClass]
    public class NamedEntityDataTests:BaseTests<NamedEntityData,BaseEntityData>

    {
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));

    }
}
