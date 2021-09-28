using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public abstract class NamedBaseTest<TClass, TBaseClass> : IdBaseTest<TClass, TBaseClass>
        where TClass : NamedEntityData, new()
        where TBaseClass : class
    {
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));
    }
}
