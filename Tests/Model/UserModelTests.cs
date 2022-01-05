using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moq;
using Tests.Model.Common;
using PageModels;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;


namespace Tests.Model
{
    [TestClass]
    public class UserModelTests
    {
        private class TestPersonRepo : TestRepo<Person>, IPersonRepo { }

        private TestRepo<Person> _repo;
        private UserModel _pageModel;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _testDb;
        private List<ApplicationUser> _users;
        private List<IdentityRole> _roles;
        private Dictionary<ApplicationUser, string> _usersAndRoles;
        private UserView _item;

        [TestInitialize]
        public void TestInitialize()
        {
            _repo = new TestPersonRepo();
            _roles = new List<IdentityRole>
            {
            new IdentityRole() { Id = "1", Name = "Viewer"},
            new IdentityRole() { Id = "2", Name = "Manager"}
            };
            _usersAndRoles = new Dictionary<ApplicationUser, String>();
            _users = new List<ApplicationUser>
            {
            new ApplicationUser() { Id = "1", UserName = "user1234"},
            new ApplicationUser() { Id = "2", UserName = "user12345"}
            };
            _userManager = MockUserManager(_users, _usersAndRoles).Object;
            _roleManager = MockRoleManager<IdentityRole>(_roles).Object;
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb").Options;
            _testDb = new ApplicationDbContext(options);
            _pageModel = new UserModel((IPersonRepo)_repo, _testDb, _userManager, null);
            _item = new UserView();
        }

        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> userList, Dictionary<TUser, string> userRoleList) 
        where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => userList.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.AddToRoleAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>(userRoleList.Add);
            
            return mgr;
        }
        public static Mock<RoleManager<TRole>> MockRoleManager<TRole>(List<TRole> list, IRoleStore<TRole> store = null)
        where TRole : class
        {
            store ??= new Mock<IRoleStore<TRole>>().Object;
            var roles = new List<IRoleValidator<TRole>> {new RoleValidator<TRole>()};
            var roleManager = new Mock<RoleManager<TRole>>(store, roles, MockLookupNormalizer(),
            new IdentityErrorDescriber(), null);

            roleManager.Setup(x => x.CreateAsync(It.IsAny<TRole>())).ReturnsAsync(IdentityResult.Success).Callback<TRole>((x) => list.Add(x));

            return roleManager;
        }
        private static ILookupNormalizer MockLookupNormalizer()
        {
            var normalizerFunc = new Func<string, string>
            (i => i == null ? null : Convert.ToBase64String(Encoding.UTF8.GetBytes(i)).ToUpperInvariant());
            var lookupNormalizer = new Mock<ILookupNormalizer>();
            lookupNormalizer.Setup(i => i.NormalizeName(It.IsAny<string>())).Returns(normalizerFunc);
            lookupNormalizer.Setup(i => i.NormalizeEmail(It.IsAny<string>())).Returns(normalizerFunc);
            return lookupNormalizer.Object;
        }

        [TestMethod] public void OnGetCreateReturnsPageTest()
        {
            var result = _pageModel.OnGetCreate();
            Assert.IsInstanceOfType(result, typeof(PageResult));
        }
        [TestMethod] public void OnPostCreateReturnsPageTest()
        {
            var result = _pageModel.OnPostCreateAsync();
            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
        }

        [TestMethod]
        public async Task CreateUserTest()
        {
            await _userManager.CreateAsync(GetUser(), "Password1.");
            Assert.AreEqual(3, _users.Count);
        }

        [TestMethod]
        public async Task CreateRoleTest()
        {
            await _roleManager.CreateAsync(GetRole());
            Assert.AreEqual(3, _roles.Count);
        }

        [TestMethod]
        public void IsPersonNotUserTest()
        {
            var result = _pageModel.IsPersonNotUser(GetUser());
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsUserNameFreeTest()
        {
            var result = _pageModel.IsUserNameFree(GetUser());
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CanCreateUserWithRoleTest()
        {
            var newUser = GetUser();
            var roleToChoose = GetRole();
            await _roleManager.CreateAsync(roleToChoose);
            Assert.AreEqual(3, _roles.Count);
            var chosenRole = _roles.Find(x => x.Id == roleToChoose.Id);
            await _userManager.CreateAsync(newUser, "Password1.");
            Assert.AreEqual(3, _users.Count);
            await _userManager.AddToRoleAsync(_users[2], _roles[2].ToString());
            Assert.AreEqual(1, _usersAndRoles.Count);
        }

        private static ApplicationUser GetUser()
        {
            return new ApplicationUser
            {
            Email = "email@email.com",
            FirstName = "Paul",
            LastName = "Keres",
            UserName = "userName",
            Id = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
            };

        }
        private static IdentityRole GetRole()
        {
            return new IdentityRole() {Id = "3", Name = "Admin"};
        }

        [TestMethod]
        public void ToApplicationUserTest()
        {
            var result = _pageModel.ToApplicationUser(_item);
            Assert.IsInstanceOfType(result, typeof(ApplicationUser));
        }
    }
}
