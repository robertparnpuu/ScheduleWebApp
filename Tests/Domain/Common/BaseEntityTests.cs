using Core;
using Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Common {

    public abstract class BaseEntityTests<TEntity, TData>
        where TEntity : BaseEntity<TData>, new()
        where TData : class, IBaseEntity, new()
    {
        protected TEntity obj;
        [TestInitialize]
        public virtual void TestInitialize() => obj = CreateObject();

        [TestMethod]
        public void IdTest() => isReadOnlyProperty(obj.id);

        protected virtual TEntity CreateObject() => new();

        protected virtual T getPropertyValue<T>(bool canWrite = false) => default;

        protected void isReadOnlyProperty<T>(T expected)
        {
            var actual = getPropertyValue<T>();

            Assert.AreEqual(expected, actual);
        }
    }
}
