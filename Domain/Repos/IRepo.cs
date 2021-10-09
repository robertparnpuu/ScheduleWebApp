using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IRepo<T>
    {
        Task<List<T>> GetEntityAsync();
        Task<T> GetAsync(string id);
        Task<bool> DeleteAsync(T obj);
        Task<bool> AddAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        T Get(string id);
        //List<T> Get();
    }
}
