using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aids;

namespace Tests {
    public abstract class AbstractClassTests<TClass, TBaseClass>: StaticClassTests
    where TClass: class 
    where TBaseClass: class {
        protected TClass Obj;
        [TestInitialize] public virtual void TestInitialize() 
        {
            Type = typeof(TClass);
            Obj = GetObject();
        }
        protected virtual TClass GetObject() => null;
        [TestMethod] public virtual void BaseClassTest() => 
            AreEqual(typeof(TBaseClass), typeof(TClass).BaseType); 
        [TestMethod] public override void IsStaticTest() => IsFalse(Type.IsAbstract && Type.IsClass && Type.IsSealed);
        [TestMethod] public virtual void IsSealedTest() => IsFalse(Type.IsSealed);
        [TestMethod] public virtual void IsAbstractTest() => IsTrue(Type.IsAbstract);
        [TestMethod] public virtual void IsClassTest() => IsTrue(Type.IsClass);
        protected static void LazyTest<TResult>(Func<bool> isValueCreated, Func<TResult> getValue, bool valueIsNull = true)
        {
            IsFalse(isValueCreated());
            var d = getValue();
            IsTrue(isValueCreated());
            if (valueIsNull) IsNull(d); else IsNotNull(d);
        }
        protected override T GetPropertyValue<T>(bool canWrite = false)
        {
            var propertyInfo = IsProperty<T>(canWrite);
            var o = (T) propertyInfo.GetValue(Obj);
            return o;
        }
        protected override void SetPropertyValue<T>(PropertyInfo p, T newValue)  
            => p.SetValue(Obj, newValue);

        protected override dynamic GetCurrentValues()
        {
            var o = GetObject();
            Copy.Members(Obj, o);
            return o;
        }
    }
}
