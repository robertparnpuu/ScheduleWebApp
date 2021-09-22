using Aids;
using Core;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Data.Common
{
    [TestClass]
    public class NamedEntityDataTests:BaseTests<NamedEntityData, BaseEntityData>
    {
        private class TestClass : NamedEntityData { }
        protected override NamedEntityData GetObject() => GetRandom.ObjectOf<TestClass>();
        [TestMethod]
        public void NameTest() => IsProperty<string>(nameof(obj.name));
    }
}
