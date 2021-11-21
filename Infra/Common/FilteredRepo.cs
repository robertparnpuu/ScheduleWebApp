using System.Linq;
using Core;
using Data.Common;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common {
    public abstract class FilteredRepo<TData, TEntity> :BaseRepo<TData, TEntity>,IFilteredRepo
        where TData : BaseEntityData, IBaseEntityData, new() {
        private string currentFilter;
        private string searchString;
        protected FilteredRepo(DbContext c = null, DbSet<TData> s = null) :base(c, s) { }
        protected internal override IQueryable<TData> CreateSql() => applyFilters(CreateSql());
        protected internal virtual IQueryable<TData> applyFilters(IQueryable<TData> query) => query;
        
        public virtual int? PageIndex { get; set; }

        public virtual string CurrentFilter {
            get => currentFilter;
            set => setFilter(value, searchString);
        }
        public virtual string SearchString {
            get => searchString;
            set => setFilter(currentFilter, value);
        }
        protected internal virtual void setFilter(string curFilter, string searchStr) {
            setPageIndex(searchStr);
            setSearchString(curFilter, searchStr);
            setCurrentFilter(searchStr);
        }
        protected internal virtual void setCurrentFilter(string searchStr)
            => currentFilter = searchStr;
        protected internal virtual void setSearchString(string curFilter, string searchStr)
            => searchString = searchStr ?? curFilter;
        protected internal virtual void setPageIndex(string searchStr)  
            => PageIndex = (searchStr == null)? PageIndex : 1;
    }
}