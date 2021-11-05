using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Domain.Repos;

namespace Tests.Model.Common
{
    public abstract class TestRepo<TClass> : IRepo<TClass> where TClass : IBaseEntity
    {
        public object result { get; set; } = null;
        public List<string> actions { get; } = new();


        public async Task<bool> AddAsync(TClass obj) => await Complete($"Add {obj?.id}"); 
        public async Task<bool> DeleteAsync(string id) => await Complete($"Delete {id}");
        public async Task<bool> UpdateAsync(TClass obj) => await Complete($"Update {obj?.id}");

        public List<TClass> GetById() => throw new System.NotImplementedException();
        public async Task<List<TClass>> GetEntityListAsync() => await GetList("List");
        public async Task<TClass> GetEntityAsync(string id) => await Item($"Get {id}");
        public TClass GetEntity(string id) => GetWithId($"Get {id}");
        private async Task<TClass> Item(string v) => await Complete(v, (TClass)result);
        private async Task<List<TClass>> GetList(string v) => await Complete(v, (List<TClass>)result);
        private async Task<TResult> Complete<TResult>(string s, TResult r)
        {
            await Complete(s);
            return r;
        }
        private async Task<bool> Complete(string s)
        {
            await Task.CompletedTask;
            actions.Add(s);
            return result is not null;
        }
        private TClass GetWithId(string s)
        {
            actions.Add(s);
            return (TClass)result;
        }
    }
}
