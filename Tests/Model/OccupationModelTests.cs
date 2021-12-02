using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class OccupationModelTests : ViewedModelTests<Occupation, OccupationView>
    {
        private class TestOccupationRepo : TestRepo<Occupation>, IOccupationRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestOccupationRepo();
            pageModel = new OccupationModel((IOccupationRepo) mockRepo, null);
        }
    }
}