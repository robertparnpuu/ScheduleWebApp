using System;
using Domain;
using Domain.Common;
using Domain.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Repos;

namespace Tests.Domain.Common
{
    [TestClass]
    public class GetRepoTests
    {
        private GetRepo Obj;
        private IServiceProvider Provider { get; set; }
        protected  GetRepo CreateObject() => new(Provider);
        [TestCleanup] public void TestCleanup() => GetRepo.SetProvider(null);
        [TestMethod] public void InstanceIsNullTest() => Assert.IsNull(GetRepo.ProviderInstance);
        [TestMethod]
        public void CanCreateTest()
        {
            InitMock();
            Assert.AreNotEqual(Provider, GetRepo.ProviderInstance);
            Assert.AreEqual(Provider, Obj.Provider);
        }
  
        [TestMethod]
        public void CreateAfterSetTest()
        {
            var p = new MockServiceProvider(null);
            GetRepo.SetProvider(p);
            Obj = new GetRepo();
            Assert.AreEqual(p, GetRepo.ProviderInstance);
            Assert.AreEqual(p, Obj.Provider);
        }
        [TestMethod]
        public void InstanceWithTypeTest()
        {
            var repo = InitMock();
            var r = Obj.Instance(typeof(IAddressRepo));
            Assert.AreEqual(repo, r);
        }
        [TestMethod]
        public void InstanceTest()
        {
            var repo = InitMock();
            var r = Obj.Instance<IAddressRepo>();
            Assert.AreEqual(repo, r);
        }
        private MockAddressRepo InitMock()
        {
            var r = new MockAddressRepo();
            Provider = new MockServiceProvider(r);
            Obj = CreateObject();
            return r;
        }
    }
}