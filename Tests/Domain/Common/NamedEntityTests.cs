using Core;
using Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Common
{
    public abstract class NamedEntityTests<TEntity, TData> : BaseEntityTests<TEntity, TData>
        where TEntity : BaseEntity<TData>, new()
        where TData : class, INamedEntity, new()
    {
        [TestMethod]
        public void NameTest() => isReadOnlyProperty(obj.Data.name);
    }
}
