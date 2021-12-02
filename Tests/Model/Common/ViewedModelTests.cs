using Aids;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Model.Common
{
    public class ViewedModelTests<TEntity, TView> : BaseModelTests<TEntity, TView>
    where TEntity : IBaseEntity, new()
    where TView : IBaseEntity

    {
        protected object OnGetDeleteAsync(string id, object result = null)
        {
            mockRepo.result = result;
            return pageModel.OnGetDeleteAsync(id).GetAwaiter().GetResult();
        }
        protected object OnGetDetailsAsync(string id, object result = null)
        {
            mockRepo.result = result;
            return pageModel.OnGetDetailsAsync(id).GetAwaiter().GetResult();
        }
        protected object OnGetEditAsync(string id, object result = null)
        {
            mockRepo.result = result;
            return pageModel.OnGetEditAsync(id).GetAwaiter().GetResult();
        }
        protected virtual object OnPostCreateAsync(dynamic newItem = null)
        {
            pageModel.item = newItem;
            return pageModel.OnPostCreateAsync().GetAwaiter().GetResult();
        }
        protected object OnPostDeleteAsync(string id, dynamic oldItem = null)
        {
            pageModel.item = oldItem;
            return pageModel.OnPostDeleteAsync(id).GetAwaiter().GetResult();
        }
        protected object OnPostEditAsync(string id, dynamic oldItem = null)
        {
            pageModel.item = oldItem;
            return pageModel.OnPostEditAsync().GetAwaiter().GetResult();
        }
        [TestMethod]
        public void OnGetDeleteAsyncTestItemNotFound()
        {
            var result = OnGetDeleteAsync(null);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void OnGetDeleteAsyncTestIdIsNull()
        {
            var result = pageModel.OnGetDeleteAsync(null).GetAwaiter().GetResult();
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void OnGetDeleteAsyncTestIsCallingGet()
        {
            pageModel.OnGetDeleteAsync("12345").GetAwaiter().GetResult();
            Assert.AreEqual("Get 12345", mockRepo.actions[0]);
        }
        [TestMethod]
        public void OnGetDeleteAsyncTestPageResult()
        {
            mockRepo.result = new TEntity();
            var result = pageModel.OnGetDeleteAsync("12345").GetAwaiter().GetResult();
            Assert.IsInstanceOfType(result, typeof(PageResult));
        }
        [TestMethod]
        public void OnGetDetailsAsyncTestItemNotFound()
        {
            var result = OnGetDetailsAsync(null);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void OnGetDetailsAsyncTestIdIsNull()
        {
            var result = pageModel.OnGetDetailsAsync(null).GetAwaiter().GetResult();
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void OnGetDetailsAsyncTestIsCallingGet()
        {
            pageModel.OnGetDetailsAsync("12345").GetAwaiter().GetResult();
            Assert.AreEqual("Get 12345", mockRepo.actions[0]);
        }
        [TestMethod]
        public void OnGetDetailsAsyncTestPageResult()
        {
            mockRepo.result = new TEntity();
            var result = pageModel.OnGetDetailsAsync("12345").GetAwaiter().GetResult();
            Assert.IsInstanceOfType(result, typeof(PageResult));
        }
        [TestMethod]
        public void OnGetEditAsyncTestItemNotFound()
        {
            var result = OnGetEditAsync(null);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void OnGetEditAsyncTestIdIsNull()
        {
            var result = pageModel.OnGetEditAsync(null).GetAwaiter().GetResult();
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void OnGetEditAsyncTestIsCallingGet()
        {
            pageModel.OnGetEditAsync("12345").GetAwaiter().GetResult();
            Assert.AreEqual("Get 12345", mockRepo.actions[0]);
        }
        [TestMethod]
        public void OnGetEditAsyncTestPageResult()
        {
            mockRepo.result = new TEntity();
            var result = pageModel.OnGetEditAsync("12345").GetAwaiter().GetResult();
            Assert.IsInstanceOfType(result, typeof(PageResult));
        }
        [TestMethod]
        public void OnGetCreatePageResult()
        {
            var result = pageModel.OnGetCreate();
            Assert.IsInstanceOfType(result, typeof(PageResult));
        }

        [TestMethod]
        public void ToEntityTestItemIsNull()
        {
            Assert.AreEqual(null, pageModel.ToEntity(null));
        }
        [TestMethod]
        public virtual void OnPostCreateTestIsCallingAdd()
        {
            var o = CreateNew.Instance<TView>();
            OnPostCreateAsync(o);
            Assert.AreEqual($"Add {o.id}", mockRepo.actions[0]);
        }
        [TestMethod]
        public void OnPostDeleteTestIsCallingDelete()
        {
            var o = CreateNew.Instance<TView>();
            OnPostDeleteAsync(o.id, o);
            Assert.AreEqual($"Delete {o.id}", mockRepo.actions[0]);
        }
        [TestMethod]
        public void OnPostEditTestIsCallingUpdate()
        {
            var o = CreateNew.Instance<TView>();
            OnPostEditAsync(o.id, o);
            Assert.AreEqual($"Update {o.id}", mockRepo.actions[0]);
        }
        [TestMethod]
        public void OnPostDeleteNotFoundResult()
        {
            var result = OnPostDeleteAsync(null);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void OnPostEditTestItemNotFound()
        {
            var result = OnPostEditAsync(null);
            Assert.IsInstanceOfType(result, typeof(PageResult));
        }
        [TestMethod]
        public void IndexPageReturnsRedirectToPageResult()
        {
            var result = pageModel.IndexPage();
            Assert.IsInstanceOfType(result, typeof(RedirectToPageResult));
        }
    }
}
