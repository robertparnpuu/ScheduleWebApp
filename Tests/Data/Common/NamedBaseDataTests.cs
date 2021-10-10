using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Common
{
    public abstract class NamedBaseDataTests<TClass, TBaseClass> : IdBaseDataTests<TClass, TBaseClass>
        where TClass : NamedEntityData, new()
        where TBaseClass : class
    {
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));
    }
}
