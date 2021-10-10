using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Tests.Aids
{
    [TestClass]
    public class CreateNewTests
    {
        internal class TestClassStr
        {
            public TestClassStr(string s) { StrField = s; }
            protected internal readonly string StrField;
        }
        internal class TestClassInt
        {
            public TestClassInt(int i) { IntField = i; }
            protected internal readonly int IntField;
        }
        [TestMethod]
        public void InstanceTest()
        {
            TestCreate<TestClassStr>();
            TestCreate<TestClassInt>();
            TestCreate<CreateNewTests>();
        }
        [DataRow(typeof(TestClassStr))]
        [DataRow(typeof(TestClassInt))]
        [DataRow(typeof(CreateNewTests))]
        [DataTestMethod]
        public void InstanceTestBtType(Type t) => TestCreate(t);
        private static void TestCreate(Type t)
        {
            var o = CreateNew.Instance(t);
            Assert.IsNotNull(o);
            Assert.IsInstanceOfType(o, t);
        }
        private static void TestCreate<T>()
        {
            var o = CreateNew.Instance<T>();
            Assert.IsNotNull(o);
            Assert.IsInstanceOfType(o, typeof(T));
        }
    }
}
