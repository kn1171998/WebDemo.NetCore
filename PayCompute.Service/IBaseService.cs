using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCompute.Service
{
    public interface IBaseService<T> where T : class
    {
        Task CreateAsync(T entity);

        T GetById(int id);

        Task UpdateAsync(T entity);

        Task UpdateAsync(int id);

        Task Delete(int id);

        IEnumerable<T> GetAll();
    }
}