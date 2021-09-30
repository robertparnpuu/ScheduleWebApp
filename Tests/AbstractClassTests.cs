using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aids;

namespace Tests {
    public abstract class AbstractClassTests<TClass, TBaseClass>
    where TClass: class 
    where TBaseClass: class
    {
        protected Type Type;
        protected TClass Obj;
        [TestInitialize] public virtual void TestInitialize() 
        {
            Type = typeof(TClass);
            Obj = GetObject();
        }
        protected virtual TClass GetObject() => null;
        [TestMethod] public virtual void BaseClassTest() => 
            Assert.AreEqual(typeof(TBaseClass), typeof(TClass).BaseType); 

        protected T GetPropertyValue<T>(bool canWrite = false)
        {
            var propertyInfo = GetPropertyInfo<T>(canWrite);
            var o = (T) propertyInfo.GetValue(Obj);
            return o;
        }

        protected PropertyInfo GetPropertyInfo<T>(bool canWrite = true)
        {
            var name = GetPropertyName();
            var propertyInfo = Type.GetProperty(name);
            Assert.IsNotNull(propertyInfo, "Not found");
            Assert.AreEqual(typeof(T), propertyInfo.PropertyType, "Wrong type");
            Assert.AreEqual(true, propertyInfo.CanRead, "Cant read");
            Assert.AreEqual(canWrite, propertyInfo.CanWrite, "CanWrite is wrong");
            return propertyInfo;
        }
        protected void IsReadOnlyProperty<T>(T expected)
        {
            var actual = GetPropertyValue<T>();
            Assert.AreEqual(expected, actual);
        }
        protected virtual void IsReadWriteProperty<T>()
        {
            var propertyInfo = GetPropertyInfo<T>();
            var actual = GetPropertyValue<T>(true);
            var expected = GetValue(actual);
            var current = GetCurrentValues();
            SetPropertyValue(propertyInfo, expected);
            actual = GetPropertyValue<T>(true);
            Assert.AreEqual(expected, actual);
            ArePropertiesEqual(current, GetCurrentValues(), propertyInfo.Name);
        }

        protected static void ArePropertiesNotEqual<T>(T expected, T actual, params string[] exceptProperties)
        {
            foreach (var p in typeof(T).GetProperties())
            {
                var expectedValue = p.GetValue(expected);
                var actualValue = p.GetValue(actual);
                if (exceptProperties.Contains(p.Name)) Assert.AreEqual(expectedValue, actualValue);
                else Assert.AreNotEqual(expectedValue, actualValue);
            }
        }
        protected static void ArePropertiesEqual<T>(T expected, T actual, params string[] exceptProperties)
        {
            foreach (var p in typeof(T).GetProperties())
            {
                var expectedValue = p.GetValue(expected);
                var actualValue = p.GetValue(actual);
                if (exceptProperties.Contains(p.Name)) Assert.AreNotEqual(expectedValue, actualValue);
                else Assert.AreEqual(expectedValue, actualValue);
            }
        }

        protected static T GetValue<T>(T value)
        {
            var v = (T)GetRandom.ValueOf<T>();
            while (value.Equals(v))
            {
                v = (T)GetRandom.ValueOf<T>();
            }
            return v;
        }

        protected dynamic GetCurrentValues()
        {
            var o = GetObject();
            Copy.Members(Obj, o);
            return o;
        }

        protected void IsReadOnlyProperty<T>() => GetPropertyInfo<T>(false);

        private readonly string[] _notPropertyNames = { nameof(GetPropertyName),
        nameof(IsReadOnlyProperty) , nameof(IsReadWriteProperty), nameof(GetPropertyInfo)
        , nameof(GetPropertyValue), nameof(GetCurrentValues),
        nameof(SetPropertyValue), nameof(GetValue)};

        protected string GetPropertyName()
        {
            var stack = new StackTrace();
            for (var idx = 0; idx < stack.FrameCount; idx++)
            {
                var n = stack.GetFrame(idx)?.GetMethod()?.Name;
                if (_notPropertyNames.Contains(n)) continue;
                return n?.Replace("Test", string.Empty);
            }
            return string.Empty;
        }
        protected void SetPropertyValue<T>(PropertyInfo p, T newValue)
            => p.SetValue(Obj, newValue);
    }
}
