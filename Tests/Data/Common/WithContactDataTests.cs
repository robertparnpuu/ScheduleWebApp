using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Common
{
    public abstract class WithContactDataTests<TClass, TBaseClass> : IdBaseDataTests<TClass, TBaseClass>
    where TClass : WithContactData, new()
    where TBaseClass : class
    {
        [TestMethod]
        public void PartyContactIdTest() => IsProperty<string>(nameof(obj.partyContactId));
    }
}