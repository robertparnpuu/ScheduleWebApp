using System.Linq;
using System.Threading.Tasks;
using Core;
using Domain.Repos;
using Infra;
using Microsoft.AspNetCore.Mvc;

namespace PageModels.Common {
    public abstract class ViewModel<TEntity, TView> :ViewedModel<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IBaseEntityData, new() {
        protected ViewModel(IRepo<TEntity> r, ApplicationDbContext c = null) :base(r, c) { }
        public virtual async Task<IActionResult> OnGetIndexAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)
        {
            PageIndex = pageIndex;
            SearchString = searchString;
            CurrentFilter = currentFilter;
            SortOrder = sortOrder;
            items = (await repo.GetEntityListAsync()).Select(ToView).ToList();
            return Page();
        }
    }
}

