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

    }
}
