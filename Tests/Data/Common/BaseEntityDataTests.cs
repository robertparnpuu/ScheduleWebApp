using Aids;
using Core;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class BaseEntityDataTests<TClass,TBaseClass>:BaseTests<BaseEntityData,IBaseEntity>
        where TClass : class, new()
        where TBaseClass : class
    {
        private class TestClass : BaseEntityData { }
        protected override BaseEntityData CreateObject() => new();
        
        [TestMethod]
        public void IdTest() => IsProperty<string>(nameof(obj.id));
        public void IsProperty<TResult>(string propertyName)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            Assert.IsNotNull(propertyInfo);

            var expected = GetRandom.ValueOf<TResult>();
            propertyInfo.SetValue(obj, expected);
            var actual = propertyInfo.GetValue(obj);
            Assert.AreEqual(expected, actual);
        }
    }
}
