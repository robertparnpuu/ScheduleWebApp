using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Common
{
    public abstract class IdBaseDataTests<TClass, TBaseClass> : BaseDataTests<TClass, TBaseClass>
        where TClass : BaseEntityData, new()
        where TBaseClass : class
    {
        [TestMethod]
        public void IdTest() => IsProperty<string>(nameof(obj.id));
    }
}
