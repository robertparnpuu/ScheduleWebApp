using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aids;
using Tests;

namespace Tests
{
    public abstract class ClassTests<TClass, TBaseClass> 
        :AbstractClassTests<TClass, TBaseClass> 
        where TClass : class, new()
        where TBaseClass : class
    {
        [TestMethod] public override void IsAbstractTest() => IsFalse(Type.IsAbstract);
        protected override TClass GetObject() => GetRandom.ObjectOf<TClass>();
        [TestMethod] public virtual void CanCreate()
            => Assert.IsInstanceOfType(new TClass(), typeof(TClass));
    }
}