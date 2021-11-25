using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class ContactModelTests : ViewedModelTests<Contact, ContactView>
    {
        private class TestContactRepo : TestRepo<Contact>, IContactRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestContactRepo();
            pageModel = new ContactModel((IContactRepo) mockRepo, null);
        }
    }
}