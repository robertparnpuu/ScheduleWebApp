using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IRepo<T> : IPagedRepo, IFilteredRepo, IOrderedRepo
    {
        Task<List<T>> GetEntityListAsync();
        Task<List<T>> GetEntityListAsync(DateTime dt1, DateTime dt2);
        Task<T> GetEntityAsync(string id);
        Task<bool> DeleteAsync(string id);
        Task<bool> AddAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        T GetEntity(string id);
        List<T> GetById();
        string ErrorMessage { get; }
    }
}
