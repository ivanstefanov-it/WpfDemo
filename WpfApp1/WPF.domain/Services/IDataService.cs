using System.Collections.Generic;
using System.Threading.Tasks;

namespace WPF.domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T Entity);
        Task<bool> Delete(T Entity);
        Task<T> Update(T Entity);
    }
}
