using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class RequirementModelTests : ViewedModelTests<Requirement, RequirementView>
    {
        private class TestRequirementRepo : TestRepo<Requirement>, IRequirementRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestRequirementRepo();
            pageModel = new RequirementModel((IRequirementRepo) mockRepo, null);
        }
    }
}