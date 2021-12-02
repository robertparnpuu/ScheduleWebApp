using System.Threading.Tasks;
using Core;
using Domain.Repos;
using Infra;
using Microsoft.AspNetCore.Mvc;

namespace PageModels.Common
{
    //Mõtleb kas vaja, hakkasin looma selleks et kasutada genericutega
    //BaseModelit ShiftAssignmentide jaoks

    public abstract class ViewedModel<TEntity, TView> : PagedModel<TEntity, TView>
    where TEntity : class, IBaseEntity, new()
    where TView : class, IBaseEntityData, new()
    {
        protected ViewedModel(IRepo<TEntity> r, ApplicationDbContext context) : base(r, context) { }
        
        internal IActionResult IndexPage() => RedirectToPage("./Index", new { handler = "Index" });

        //public virtual async Task OnGetIndexAsync() => items = (await repo.GetEntityListAsync()).Select(ToView).ToList();
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

        public virtual async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            return await repo.AddAsync(ToEntity(item)) ? IndexPage() : Page();
        }
        public virtual async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            return await repo.DeleteAsync(id) ? IndexPage() : Page();
        }
        public virtual async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            return await repo.UpdateAsync(ToEntity(item)) ? IndexPage() : Page();
        }
    }
}
