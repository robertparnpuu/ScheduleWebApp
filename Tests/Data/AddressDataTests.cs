using Aids;
using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Data.Common;

namespace Tests.Data
{
    [TestClass]
    public class AddressDataTests:BaseEntityDataTests<AddressData,BaseEntityData>
    {
        private class TestClass : AddressData { }
        protected override AddressData CreateObject() => GetRandom.ObjectOf<TestClass>();
        [TestMethod]
        public void ApartmentNumberTest() => IsProperty<string>(nameof(obj.id));

        public string apartmentNumber { get; set; }
        public string streetName { get; set; }
        public string houseNumber { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string region { get; set; }
        public string country { get; set; }
    }
}
