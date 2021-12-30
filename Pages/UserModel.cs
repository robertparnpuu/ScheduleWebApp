using System;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
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
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;


namespace PageModels
{
    [Authorize(Roles = "Admin")]
    public class UserModel : PageModel
    {
        protected readonly IPersonRepo repo;
        protected readonly ApplicationDbContext _context;
        [BindProperty] public UserView item { get; set; }

        protected readonly UserManager<ApplicationUser> _userManager;

        public UserModel(IPersonRepo r, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            repo = r;
            _context = context;
            item = new UserView();
            _userManager = userManager;
        }

        public SelectList Persons
        {
            get
            {
                var list = new GetRepo().Instance<IPersonRepo>().GetById();
                return new SelectList(list, "id", "fullName", item?.userPersonId);
            }
        }
        public IActionResult OnGetCreate() => Page();

        public virtual async Task<IActionResult> OnPostCreateAsync()
        {
            if (ModelState.IsValid)
            {
                var user = ToApplicationUser(item);
                if (IsPersonNotUser(user))
                {
                    var result = await _userManager.CreateAsync(user, item.password);
                    if (result.Succeeded)
                    {
                        return RedirectToPage("./UserCreated");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Page();
        }

        protected internal ApplicationUser ToApplicationUser(UserView obj)
        {
            ApplicationUser newUser = new ApplicationUser();
            newUser.PersonId = obj.userPersonId;
            newUser.Email = repo.GetEntity(obj.userPersonId).email;
            newUser.FirstName = repo.GetEntity(obj.userPersonId).firstName;
            newUser.LastName = repo.GetEntity(obj.userPersonId).lastName;
            newUser.UserName = obj.userName;
            newUser.Id = Guid.NewGuid().ToString();
            newUser.EmailConfirmed = true;
            newUser.PhoneNumberConfirmed = true;
            return newUser;
        }

        private bool IsPersonNotUser(ApplicationUser user)
        {
            var result = _context.Users.FirstOrDefault(x => x.PersonId == user.PersonId);
            if (result == null)
            {
                return true;
            }
            return false;
        }


    }
} 