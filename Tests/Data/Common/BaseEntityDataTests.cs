using Core;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Common
{
    [TestClass]
    public class BaseEntityDataTests:BaseTests<BaseEntityData,IBaseEntity>
    {        
        [TestMethod]
        public void IdTest() => IsProperty<string>(nameof(obj.id));
        
    }
}
