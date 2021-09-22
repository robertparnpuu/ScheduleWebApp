using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    
    public abstract class BaseTests<TClass, TBaseClass>
        where TClass : class, new()
        where TBaseClass : class
    {
        protected TClass obj;

        [TestInitialize]
        public virtual void TestInitialize() => obj = CreateObject();
        protected virtual TClass CreateObject() => new TClass();
                   
        public void IsProperty<TResult>(string propertyName)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            Assert.IsNotNull(propertyInfo);

            var expected = GetRandom.ValueOf<TResult>();
            propertyInfo.SetValue(obj, expected);
            var actual = propertyInfo.GetValue(obj);
            Assert.AreEqual(expected, actual);
        }
        protected virtual TClass GetObject() => GetRandom.ObjectOf<TClass>();
        protected static void AreEqual<TExpected, TActual>(TExpected e, TActual a) => Assert.AreEqual(e, a);
        protected static void AreNotEqual<TExpected, TActual>(TExpected e, TActual a) => Assert.AreNotEqual(e, a);
        protected static void IsNull(object o, string msg = null) => Assert.IsNull(o, msg ?? string.Empty);
        protected static void IsNotNull(object o) => Assert.IsNotNull(o);
        protected static void IsFalse(bool b) => Assert.IsFalse(b);
        protected static void IsTrue(bool b, string s = null)
        {
            if (s is null) Assert.IsTrue(b);
            else Assert.IsTrue(b, s);
        }
        protected static void NotTested(string message) => Assert.Inconclusive(message);
        protected static void NotTested(string message, params object[] parameters)
            => Assert.Inconclusive(message, parameters);

    }
}
