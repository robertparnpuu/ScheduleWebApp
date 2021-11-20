using Core;

namespace Tests.Model.Common
{
    public class BaseModelTests<TEntity, TView>
       where TEntity : IBaseEntity, new()
       where TView : IBaseEntity
    {
        protected dynamic pageModel;
        protected TestRepo<TEntity> mockRepo;
    }
}