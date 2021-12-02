using Core;
using Domain.Repos;
using Infra;

namespace PageModels.Common {
    public abstract class PagedModel<TEntity, TView> :OrderedModel<TEntity, TView>,IPagedRepo
        where TEntity : class, IBaseEntity, new()
        where TView : class, IBaseEntityData, new() {
        protected PagedModel(IRepo<TEntity> r, ApplicationDbContext c = null) :base(r, c) { }
        public override bool HasNextPage => repo.HasNextPage;
        public override bool HasPreviousPage => repo.HasPreviousPage;
        public override int? PageIndex {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }

        public int TotalPages { get; set; }
        public int PageSize { get; set ; }
    }
}
