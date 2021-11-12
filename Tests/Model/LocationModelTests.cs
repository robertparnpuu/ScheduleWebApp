using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class LocationModelTests : ViewedModelTests<Location, LocationView>
    {
        private class TestLocationRepo : TestRepo<Location>, ILocationRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestLocationRepo();
            pageModel = new LocationModel((ILocationRepo) mockRepo, null);
        }
    }
}