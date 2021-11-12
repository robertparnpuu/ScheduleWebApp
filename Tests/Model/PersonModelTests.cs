using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class PersonModelTests : ViewedModelTests<Person, PersonView>
    {
        private class TestPersonRepo : TestRepo<Person>, IPersonRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestPersonRepo();
            pageModel = new PersonModel((IPersonRepo) mockRepo, null);
        }
    }
}