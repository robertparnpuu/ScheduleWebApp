using Aids;
using Core;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class BaseEntityDataTests:BaseTests<BaseEntityData,IBaseEntity>
    {
        private class TestClass : BaseEntityData { }
        protected override BaseEntityData GetObject() => GetRandom.ObjectOf<TestClass>();
        [TestMethod]
        public void IdTest() => IsProperty<string>(nameof(obj.id));
    }
}
