using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Tests.Model.Common
{

    public static class MockHelpers
    {
        //public static StringBuilder LogMessage = new StringBuilder();
        //public static List<IdentityRole> identityRoles = new List<IdentityRole>();

        //public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        //{
        //    var store = new Mock<IUserStore<TUser>>();
        //    var mockUserManager = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
        //    mockUserManager.Object.UserValidators.Add(new UserValidator<TUser>());
        //    mockUserManager.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
        //    List<UserManager<TUser>> ls = new List<UserManager<TUser>>();
        //    mockUserManager.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
        //    mockUserManager.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).
        //    ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
        //    mockUserManager.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

        //    return mockUserManager;
        //}
        //public Mock<UserManager<ApplicationUser>> = MockUserManager<ApplicationUser> 

        //public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        //{
        //    var store = new Mock<IUserStore<TUser>>();
        //    var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
        //    mgr.Object.UserValidators.Add(new UserValidator<TUser>());
        //    mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

        //    mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
        //    mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
        //    mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
        //    return mgr;
        //}

        public static Mock<RoleManager<TRole>> MockRoleManager<TRole>(IRoleStore<TRole> store = null)
        where TRole : class
        {
            store ??= new Mock<IRoleStore<TRole>>().Object;
            var roles = new List<IRoleValidator<TRole>>();
            roles.Add(new RoleValidator<TRole>());
            return new Mock<RoleManager<TRole>>(store, roles, MockLookupNormalizer(),
            new IdentityErrorDescriber(), null);
        }

        //public static UserManager<TUser> TestUserManager<TUser>(IUserStore<TUser> store = null) where TUser : class
        //{
        //    store = store ?? new Mock<IUserStore<TUser>>().Object;
        //    var options = new Mock<IOptions<IdentityOptions>>();
        //    var idOptions = new IdentityOptions();
        //    idOptions.Lockout.AllowedForNewUsers = false;
        //    options.Setup(o => o.Value).Returns(idOptions);
        //    var userValidators = new List<IUserValidator<TUser>>();
        //    var validator = new Mock<IUserValidator<TUser>>();
        //    userValidators.Add(validator.Object);
        //    var pwdValidators = new List<PasswordValidator<TUser>>();
        //    pwdValidators.Add(new PasswordValidator<TUser>());
        //    var userManager = new UserManager<TUser>(store, options.Object, new PasswordHasher<TUser>(),
        //    userValidators, pwdValidators, MockLookupNormalizer(),
        //    new IdentityErrorDescriber(), null,
        //    new Mock<ILogger<UserManager<TUser>>>().Object);
        //    validator.Setup(v => v.ValidateAsync(userManager, It.IsAny<TUser>()))
        //    .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
        //    return userManager;
        //}

        //public static RoleManager<TRole> TestRoleManager<TRole>(IRoleStore<TRole> store = null) where TRole : class
        //{
        //    store = store ?? new Mock<IRoleStore<TRole>>().Object;
        //    var roles = new List<IRoleValidator<TRole>>();
        //    roles.Add(new RoleValidator<TRole>());
        //    return new RoleManager<TRole>(store, roles,
        //    MockLookupNormalizer(),
        //    new IdentityErrorDescriber(),
        //    null);
        //}

        public static ILookupNormalizer MockLookupNormalizer()
        {
            var normalizerFunc = new Func<string, string>
            (i => i == null ? null : Convert.ToBase64String(Encoding.UTF8.GetBytes(i)).ToUpperInvariant());
            var lookupNormalizer = new Mock<ILookupNormalizer>();
            lookupNormalizer.Setup(i => i.NormalizeName(It.IsAny<string>())).Returns(normalizerFunc);
            lookupNormalizer.Setup(i => i.NormalizeEmail(It.IsAny<string>())).Returns(normalizerFunc);
            return lookupNormalizer.Object;
        }
    }
}