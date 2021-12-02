using Domain;
using Domain.Repos;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModels;
using Tests.Model.Common;

namespace Tests.Model
{
    [TestClass] public class StandardShiftModelTests : ViewedModelTests<StandardShift, StandardShiftView>
    {
        private class TestStandardShiftRepo : TestRepo<StandardShift>, IStandardShiftRepo{ }

        [TestInitialize] public void TestInitialize()
        {
            mockRepo = new TestStandardShiftRepo();
            pageModel = new StandardShiftModel((IStandardShiftRepo) mockRepo, null);
        }
    }
}