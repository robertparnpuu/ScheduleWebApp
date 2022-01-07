using System;
using System.Linq;
using Core;
using Data.Common;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common
{
    public abstract class PagedRepo<TData, TEntity> :OrderedRepo<TData, TEntity>, IRepo<TEntity>
        where TData : BaseEntityData, IBaseEntityData, new() {
        private int pageIndex;

        public const int DefaultPageSize = 5;
        protected PagedRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s) { }
        public override int? PageIndex {
            get => pageIndex;
            set => pageIndex = value ?? 1;
        }
        public virtual int TotalPages => getTotalPages(PageSize);
        public virtual bool HasNextPage => pageIndex < TotalPages;
        public virtual bool HasPreviousPage => pageIndex > 1;
        public virtual int PageSize { get; set; } = DefaultPageSize;
     

        internal int getTotalPages(in int pageSize) {
            var count = getItemsCount();
            var pages = countTotalPages(count, pageSize);
            return pages;
        }
        internal static int countTotalPages(int count, in int pageSize) 
            => (int)Math.Ceiling( count / (double)pageSize);
        internal virtual int getItemsCount() => base.CreateSql().Count();
        protected internal override IQueryable<TData> CreateSql() => addSkipAndTake(base.CreateSql());
        
        internal virtual IQueryable<TData> addSkipAndTake(IQueryable<TData> query) {
            if (pageIndex < 1) return query;
            return query
                .Skip((pageIndex - 1) * PageSize)
                .Take(PageSize);
        }
    }
}
