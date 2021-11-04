using System;
using Aids;
using Core;
using Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Aids;

namespace Tests.Facade.Common
{
    public abstract class BaseViewTests<TView>:UniqueItem
    where TView:BaseView,new()
    {
        protected TView obj;
        [TestInitialize]
        public virtual void TestInitialize() => obj = CreateObject();
        protected virtual TView CreateObject() => GetRandom.ObjectOf<TView>();
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
