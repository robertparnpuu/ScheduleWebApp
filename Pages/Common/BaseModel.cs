using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Domain.Repos;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageModels.Common
{

    public abstract class BaseModel : PageModel, IBasePage
    { 
        [BindProperty] 
        public IBaseEntity item { get; set; }
    }

    public abstract class BaseModel<TEntity, TView> : BaseModel
    where TEntity : class, IBaseEntity, new()
    where TView : class, IBaseEntity, new()
    {
        protected readonly IRepo<TEntity> repo;
        protected readonly ApplicationDbContext _context;

        protected BaseModel(IRepo<TEntity> r, ApplicationDbContext context)
        {
            repo = r;
            _context = context;
        }

        [BindProperty]
        public new TView item
        {
            get => (TView)base.item;
            set => base.item = value;
        }
        public IList<TView> items { get; set; }
        protected internal abstract TView ToView(TEntity obj);
        protected internal abstract TEntity ToEntity(TView view);
        internal IActionResult IndexPage() => RedirectToPage("./Index", new { handler = "Index" });

        public virtual async Task OnGetIndexAsync() => items = (await repo.GetEntityListAsync()).Select(ToView).ToList();
        public IActionResult OnGetCreate() => Page();

        public async Task<IActionResult> OnGetDeleteAsync(string id) => await GetItemAsync(id) ? Page() : NotFound();
        public async Task<IActionResult> OnGetDetailsAsync(string id) => await GetItemAsync(id) ? Page() : NotFound();
        public async Task<IActionResult> OnGetEditAsync(string id) => await GetItemAsync(id) ? Page() : NotFound();

        protected internal virtual async Task<bool> GetItemAsync(string id)
        {
            if (id == null) return false;

            item = ToView(await repo.GetEntityAsync(id));

            return item != null && item.id != "Unspecified";
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            return await repo.AddAsync(ToEntity(item)) ? IndexPage() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            return await repo.DeleteAsync(id) ? IndexPage() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            return await repo.UpdateAsync(ToEntity(item)) ? IndexPage() : Page();
        }
    }
}
