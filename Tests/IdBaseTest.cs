using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public abstract class IdBaseTest<TClass, TBaseClass> : BaseTests<TClass, TBaseClass>
        where TClass : BaseEntityData, new()
        where TBaseClass : class
    {
        [TestMethod]
        public void IDTest() => IsProperty<string>(nameof(obj.id));
    }
}
