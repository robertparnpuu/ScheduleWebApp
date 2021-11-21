using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Aids;
using Core;
using Data.Common;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common {
    public abstract class OrderedRepo<TData, TEntity> :FilteredRepo<TData, TEntity>,IOrderedRepo
        where TData : BaseEntityData, IBaseEntityData, new() {
        private string sortOrder;
        protected OrderedRepo(DbContext c = null, DbSet<TData> s = null) :base(c, s) { }
        public virtual string SortOrder {
            get => getSortOrder();
            set => sortOrder = value;
        }
        public virtual string CurrentSort => sortOrder;

        protected internal virtual string getSortOrder()
            => sortOrder?.Contains("_desc") ?? true ? removeDesc(sortOrder) : addDesc(sortOrder);
        protected internal virtual string addDesc(string s) => $"{s}_desc";
        protected internal virtual string removeDesc(string s)
            => s?.Replace("_desc", string.Empty) ?? string.Empty;
        protected internal override IQueryable<TData> CreateSql() => addSorting(base.CreateSql());
        protected internal IQueryable<TData> addSorting(IQueryable<TData> query) {
            var expression = createExpression();
            var r = expression is null ? query : addOrderBy(query, expression);
            return r;
        }
        internal Expression<Func<TData, object>> createExpression() {
            var property = findProperty();
            return property is null ? null : lambdaExpression(property);
        }
        internal static Expression<Func<TData, object>> lambdaExpression(PropertyInfo p) {
            var param = Expression.Parameter(typeof(TData), "x");
            var property = Expression.Property(param, p);
            var body = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TData, object>>(body, param);
        }
        internal PropertyInfo findProperty() {
            var name = getName();
            return typeof(TData).GetProperty(name);
        }
        internal string getName() {
            if (string.IsNullOrEmpty(sortOrder)) return string.Empty;
            var s = removeDesc(sortOrder);
            return s;
        }
        internal IQueryable<TData> addOrderBy(IQueryable<TData> query, Expression<Func<TData, object>> e) {
            if (query is null) return null;
            if (e is null) return query;
            return Safe.Run(() => isDescending()
                ? query.OrderByDescending(e)
                : query.OrderBy(e), query);
        }
        internal bool isDescending() =>
            !string.IsNullOrEmpty(sortOrder) && sortOrder.EndsWith("_desc");
    }
}