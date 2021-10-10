using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IRepo<T>
    {
        Task<List<T>> GetEntityListAsync();
        Task<T> GetEntityAsync(string id);
        Task<bool> DeleteAsync(string id);
        Task<bool> AddAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        T Get(string id);
        //List<T> Get();
    }
}
