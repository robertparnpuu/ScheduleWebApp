using System.Collections.Generic;
using Core;
using Domain.Repos;
using Infra;

namespace PageModels.Common {
    public abstract class FilteredModel<TEntity, TView> :BaseModel<TEntity, TView>,IFilteredRepo
        where TEntity : class, IBaseEntity, new()
        where TView : class, IBaseEntityData, new() {
        protected FilteredModel(IRepo<TEntity> r, ApplicationDbContext c = null) : base(r, c) { }

        public IList<TView> Items { get; set; }
        public override string CurrentFilter {
            get => repo.CurrentFilter;
            set => repo.CurrentFilter = value;
        }
        public override string SearchString {
            get => repo.SearchString;
            set => repo.SearchString = value;
        }
    }
}
