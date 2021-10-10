using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Aids
{
    [TestClass]
    public class GetRandomTests
    {
        internal class TestClass
        {
            public string Str { get; set; }
            public int Int { get; set; }
            public DateTime DateTime { get; set; }
            public decimal Decimal { get; set; }
            public bool Boolean { get; set; }
            public double Double { get; set; }
            public float Float { get; set; }
        }

        [TestMethod]
        public void GetMinTest()
            => Assert.AreEqual(double.MinValue,
                GetRandom.GetMin(double.MinValue, double.MaxValue));

        [TestMethod]
        public void GetMaxTest()
            => Assert.AreEqual(double.MaxValue,
                GetRandom.GetMax(double.MinValue, double.MaxValue));

        [TestMethod] public void DoubleTest() => DoTests(GetRandom.Double, double.MinValue, double.MaxValue);
        [TestMethod] public void FloatTest() => DoTests(GetRandom.Float, float.MinValue, float.MaxValue);
        [TestMethod] public void Int64Test() => DoTests(GetRandom.Int64, long.MinValue, long.MaxValue);
        [TestMethod] public void Int32Test() => DoTests(GetRandom.Int32, int.MinValue, int.MaxValue);
        [TestMethod] public void Int16Test() => DoTests(GetRandom.Int16, short.MinValue, short.MaxValue);
        [TestMethod] public void Int8Test() => DoTests(GetRandom.Int8, sbyte.MinValue, sbyte.MaxValue);
        [TestMethod] public void UInt64Test() => DoTests(GetRandom.UInt64, ulong.MinValue, ulong.MaxValue);
        [TestMethod] public void UInt32Test() => DoTests(GetRandom.UInt32, uint.MinValue, uint.MaxValue);
        [TestMethod] public void UInt16Test() => DoTests(GetRandom.UInt16, ushort.MinValue, ushort.MaxValue);
        [TestMethod] public void UInt8Test() => DoTests(GetRandom.UInt8, byte.MinValue, byte.MaxValue);
        [TestMethod] public void DecimalTest() => DoTests(GetRandom.Decimal, decimal.MinValue, decimal.MaxValue);
        [TestMethod]
        public void ObjectTest()
        {
            var o = GetRandom.ObjectOf<TestClass>();
            Assert.AreNotEqual(0M, o.Decimal);
            Assert.AreNotEqual(0, o.Int);
            Assert.AreNotEqual(null, o.Str);
            Assert.AreNotEqual(0d, o.Double);
            Assert.AreNotEqual(0f, o.Float);
            Assert.IsTrue(o.DateTime < DateTime.MaxValue);
            Assert.IsTrue(o.DateTime > DateTime.MinValue);
        }
        private static void DoTests<T>(Func<T, T, T> f, T min, T max) where T : IComparable
        {
            var x = f(min, max);
            var y = f(x, max);
            var i = f(x, y);
            Assert.IsTrue(x.CompareTo(i) <= 0 && i.CompareTo(y) <= 0);
        }
    }
}
