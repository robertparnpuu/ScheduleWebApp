using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Common;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PageModels
{
    [Authorize(Roles = "Admin,Manager")]
    public class UserModel : PageModel
    {
        [BindProperty] public UserView item { get; set; }
        [BindProperty] public IdentityRole role { get; set; }

        private readonly IPersonRepo repo;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserModel(IPersonRepo r, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            repo = r;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            item = new UserView();
            role = new IdentityRole();
        }

        public SelectList Persons
        {
            get
            {
                var list = new GetRepo().Instance<IPersonRepo>().GetById();
                return new SelectList(list, "id", "fullName", item?.userPersonId);
            }
        }

        public SelectList Roles
        {
            get
            {
                var list = _roleManager.Roles.ToList();
                return new SelectList(list, "Id", "Name", role?.Id);
            }
        }

        public IActionResult OnGetCreate() => Page();

        public virtual async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            var user = ToApplicationUser(item);
            if (!IsUserNameFree(user)) return RedirectToPage("./UserNameAlreadyTaken");
            if (!IsPersonNotUser(user)) return RedirectToPage("./UserAlreadyExists");
            IdentityRole chosenRole = _roleManager.FindByIdAsync(role.Id).GetAwaiter().GetResult();
            if (!CanAssignRole(chosenRole)) return RedirectToPage("./CantAssignRole");
            var userResult = await _userManager.CreateAsync(user, item.password);
            var roleResult = await _userManager.AddToRoleAsync(user, chosenRole.Name);
            if (chosenRole.Name != Enums.Roles.Viewer.ToString()) await _userManager.AddToRoleAsync(user, Enums.Roles.Viewer.ToString());
            if (userResult.Succeeded && roleResult.Succeeded) return RedirectToPage("./UserCreated");
            foreach (var error in userResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            foreach (var error in roleResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
         }

        protected internal ApplicationUser ToApplicationUser(UserView obj)
        {
            var newUser = new ApplicationUser
            {
            PersonId = obj.userPersonId,
            Email = repo.GetEntity(obj.userPersonId)?.email,
            FirstName = repo.GetEntity(obj.userPersonId)?.firstName,
            LastName = repo.GetEntity(obj.userPersonId)?.lastName,
            UserName = obj.userName,
            Id = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
            };
            return newUser;
        }

        internal bool IsPersonNotUser(ApplicationUser user)
        {
            var result = _context.Users.FirstOrDefault(x => x.PersonId == user.PersonId);
            return result == null;
        }

        internal bool IsUserNameFree(ApplicationUser user)
        {
            var result = _context.Users.FirstOrDefault(x => x.UserName == user.UserName);
            return result == null;
        }
        internal bool CanAssignRole(IdentityRole role)
        {
            if (role.Name == Enums.Roles.Manager.ToString() && !(User.IsInRole(Enums.Roles.Admin.ToString()))) return false;
            if (role.Name == Enums.Roles.Admin.ToString() && !(User.IsInRole(Enums.Roles.Admin.ToString()))) return false;
            return User.IsInRole(Enums.Roles.Admin.ToString()) || User.IsInRole(Enums.Roles.Manager.ToString());
        }
     }
}