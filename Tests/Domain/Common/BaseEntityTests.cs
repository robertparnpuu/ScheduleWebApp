using Core;
using Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Aids;
// ReSharper disable InconsistentNaming

namespace Tests.Domain.Common {

    public abstract class BaseEntityTests<TEntity, TData>
        where TEntity : BaseEntity<TData>, new()
        where TData : class, IBaseEntity, new()
    {
        protected TEntity obj;
        [TestInitialize]
        public virtual void TestInitialize() => obj = CreateObject();

        [TestMethod]
        public void IdTest() => Assert.IsTrue(IsGuid(obj.Data.id));

        protected virtual TEntity CreateObject() => GetRandom.ObjectOf<TEntity>();

        protected virtual T getPropertyValue<T>(bool canWrite = false) => default;

        protected void isReadOnlyProperty<T>(T expected)
        {
            var actual = getPropertyValue<T>();

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestAllDefaultProperties()
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "id") Assert.IsTrue(IsGuid(property.GetValue(obj)));                
                else if (property.PropertyType == typeof(string)) Assert.IsTrue(ContainsOnly(",- ",property.GetValue(obj)));
                else if (property.PropertyType == typeof(int)) Assert.IsNull(property.GetValue(obj));
                else if (property.PropertyType == typeof(DateTime)) Assert.AreEqual(default(DateTime), property.GetValue(obj));
            }
        }
        
        public static bool IsGuid(object value) => Guid.TryParse(value.ToString(), out _);

        private static bool ContainsOnly(string chars,dynamic format)
        {
            foreach (char c in format)
            {
                if (!chars.Contains(c.ToString()))
                    return false;
            }
            return true;
        }
        protected static void LazyTest<TResult>(Func<bool> isValueCreated, Func<TResult> getValue, bool valueIsNull = true)
        {
            Assert.IsFalse(isValueCreated());
            var d = getValue();
            Assert.IsTrue(isValueCreated());
            if (valueIsNull) Assert.IsNull(d); else Assert.IsNotNull(d);
        }
    }
    
}
