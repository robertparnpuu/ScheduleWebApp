using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aids;
using Data;
using Domain.Common;

namespace Tests.Domain.Common {

    [TestClass] public class BaseEntityTests : AbstractClassTests<BaseEntity<AddressData>, object>
    {
        private class TestClass : BaseEntity<AddressData>
        { 
            public TestClass(AddressData d = null) : base(d) { }
        }

        protected override BaseEntity<AddressData> GetObject() => new TestClass(GetRandom.ObjectOf<AddressData>());
        
        [TestMethod] public void DataTest() 
        {
            IsReadOnlyProperty<AddressData>();
            Assert.AreNotSame(Obj.Data, Obj.Data);
            Assert.AreNotEqual(Obj.Data, Obj.Data);
            ArePropertiesEqual(Obj.Data, Obj.Data);
            var actual = Obj.Data;
            var expected = GetRandom.ObjectOf<AddressData>();
            Copy.Members(expected, actual);
            ArePropertiesEqual(expected, actual);
            ArePropertiesNotEqual(expected, Obj.Data);
        }

        [TestMethod] public void idTest() => IsReadOnlyProperty(Obj.Data.id);

        [TestMethod] public void apartmentNumberTest() => IsReadOnlyProperty(Obj.Data.apartmentNumber);

    }
}
