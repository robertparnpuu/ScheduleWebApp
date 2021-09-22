using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aids;
using Data.Common;
using Domain.Common;

namespace Tests.Domain.Common 
{
    [TestClass] public class BaseEntityTests : AbstractClassTests<BaseEntity<BaseEntityData>, object>
    {
        private class TestClass :BaseEntity<BaseEntityData>
        {
            public TestClass(BaseEntityData d = null) : base(d) { }
        }

        protected override BaseEntity<BaseEntityData> GetObject() => new TestClass(GetRandom.ObjectOf<BaseEntityData>());
        
        [TestMethod] public void DataTest() 
        {
            IsReadOnlyProperty<BaseEntityData>();
            Assert.AreNotSame(Obj.Data, Obj.Data);
            Assert.AreNotEqual(Obj.Data, Obj.Data);
            ArePropertiesEqual(Obj.Data, Obj.Data);
            var actual = Obj.Data;
            var expected = GetRandom.ObjectOf<BaseEntityData>();
            Copy.Members(expected, actual);
            ArePropertiesEqual(expected, actual);
            ArePropertiesNotEqual(expected, Obj.Data);
        }

        [TestMethod] public void idTest() => IsReadOnlyProperty(Obj.Data.id);
    }
}
