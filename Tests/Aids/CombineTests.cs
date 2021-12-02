using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Aids
{
    [TestClass]
    public class CombineTests
    {
        [TestMethod]
        public void TestDateAndTime()
        {
            DateTime date = new DateTime(2021, 12, 21);
            DateTime time = new DateTime(1, 1, 1, 14, 30, 15);
            DateTime result = Combine.DateAndTime(date, time);
            Assert.AreEqual(new DateTime(2021, 12, 21, 14, 30, 15), result);
        }
    }
}
