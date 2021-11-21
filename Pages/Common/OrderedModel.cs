using Core;
using Domain.Repos;
using Infra;

namespace PageModels.Common {
    public abstract class OrderedModel<TEntity, TView> :FilteredModel<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IBaseEntityData, new() {
        protected OrderedModel(IRepo<TEntity> r, ApplicationDbContext c = null) :base(r, c) { }

        public override string SortOrder {
            get => repo.SortOrder;
            set => repo.SortOrder = value;
        }
        public override string CurrentSort => repo.CurrentSort;
    }
}
