using System;
using Aids;
using Core;
using Domain.Repos;

namespace Domain.Common 
{
    public abstract class BaseEntity<TData> :IBaseEntity
        where TData : class, IBaseEntity, new() {
        protected readonly TData data;

        protected BaseEntity() :this(null) { }
        protected BaseEntity(TData d) => data = d;

        public TData Data => Copy.Members(data, new TData()) ?? new TData();
        public string id => Data?.id ?? "Unspecified";

        internal static Lazy<TEntity> GetLazy<TEntity, TRepo>(Func<TRepo, TEntity> func)
            where TEntity : IBaseEntity where TRepo : IRepo<TEntity> =>
            new(() => func(GetRepo<TRepo>()));

        internal static TRepo GetRepo<TRepo>() => new GetRepo().Instance<TRepo>();

    }
}




