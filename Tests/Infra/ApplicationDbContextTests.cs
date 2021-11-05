using Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra
{
    [TestClass]
    public class ApplicationDbContextTests
    {
        [TestMethod]
        public void CanCreate()
            => Assert.IsInstanceOfType(new ApplicationDbContext(), typeof(IdentityDbContext));
    }
}
