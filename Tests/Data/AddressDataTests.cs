using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class AddressDataTests:NamedEntityData
    {
        [TestMethod]
        public void AparmentNumberTest() => IsProperty<string>(nameof(obj.apartmentNumber));
        [TestMethod]
        public void IdTest() => IsProperty<string>(nameof(obj.id));

        public string apartmentNumber { get; set; }
        public string streetName { get; set; }
        public string houseNumber { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string region { get; set; }
        public string country { get; set; }
    }
}
