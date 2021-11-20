using Aids;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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