using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests.Aids
{
    [TestClass]
    public class GetEnumTests
    {
        private enum TestEnum
        {
            Undefined = 0,
            First = 1,
            Second = 123
        }
        [TestMethod]
        public void CountTest()
            => Assert.AreEqual(3, GetEnum.Count<TestEnum>());
        [TestMethod]
        public void CountTestByType()
            => Assert.AreEqual(3, GetEnum.Count(typeof(TestEnum)));

        [TestMethod]
        public void ValueByIndexTest()
            => Assert.AreEqual(TestEnum.First, GetEnum.ValueByIndex<TestEnum>(1));
        [TestMethod]
        public void ValueByIndexTestByType()
            => Assert.AreEqual(TestEnum.Second, GetEnum.ValueByIndex(typeof(TestEnum), 2));

        [TestMethod]
        public void ValueByValueTest()
            => Assert.AreEqual(TestEnum.First, GetEnum.ValueByValue<TestEnum>(1));
        [TestMethod]
        public void ValueByValueTestByType()
            => Assert.AreEqual(TestEnum.Second, GetEnum.ValueByValue(typeof(TestEnum), 123));

        [TestMethod]
        public void CountTestWrongType()
            => Assert.AreEqual(-1, GetEnum.Count<string>());
        [TestMethod]
        public void CountTestByTypeWrongType()
            => Assert.AreEqual(-1, GetEnum.Count(typeof(int)));

        [TestMethod]
        public void ValueByIndexTestWrongIndex()
            => Assert.AreEqual(TestEnum.Undefined, GetEnum.ValueByIndex<TestEnum>(100));
        [TestMethod]
        public void ValueByIndexTestByTypeWrongIndex()
            => Assert.AreEqual(TestEnum.Undefined, GetEnum.ValueByIndex(typeof(TestEnum), 100));

        [TestMethod]
        public void ValueByValueTestWrongIndex()
            => Assert.AreEqual(TestEnum.Undefined, GetEnum.ValueByValue<TestEnum>(100));
        [TestMethod]
        public void ValueByValueTestByTypeWrongIndex()
            => Assert.AreEqual(TestEnum.Undefined, GetEnum.ValueByValue(typeof(TestEnum), 100));

        [TestMethod]
        public void ValueByIndexTestWrongType()
            => Assert.AreEqual(null, GetEnum.ValueByIndex<string>(100));
        [TestMethod]
        public void ValueByIndexTestByTypeWrongType()
            => Assert.AreEqual(null, GetEnum.ValueByIndex(typeof(string), 100));

        [TestMethod]
        public void ValueByValueTestWrongType()
            => Assert.AreEqual(0, GetEnum.ValueByValue<int>(100));
        [TestMethod]
        public void ValueByValueTestByTypeWrongType()
            => Assert.AreEqual(0, GetEnum.ValueByValue(typeof(int), 100));

    }
}
