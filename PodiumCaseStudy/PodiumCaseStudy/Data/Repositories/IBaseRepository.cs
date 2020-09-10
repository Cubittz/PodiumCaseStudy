using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<T> CreateAsync(T entity);
    }
}
