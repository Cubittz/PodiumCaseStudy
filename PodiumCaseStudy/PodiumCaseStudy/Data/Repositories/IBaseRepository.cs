using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);

        Task<T> CreateAsync(T entity);
    }
}
