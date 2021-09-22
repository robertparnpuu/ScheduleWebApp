using Aids;
using Core;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Data.Common
{
    [TestClass]
    public class NamedEntityDataTests<TClass,TBaseClass>:BaseEntityDataTests<NamedEntityData,BaseEntityData>
        where TClass : class, new()
        where TBaseClass : class
    {
        private class TestClass : NamedEntityData { }
        protected override NamedEntityData CreateObject() => new();
        [TestMethod]
        public void NameTest() => IsProperty<string>(obj.id);

    }
}
