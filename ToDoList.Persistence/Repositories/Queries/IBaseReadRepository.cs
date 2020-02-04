using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Persistence.Repositories.Queries
{
    public interface IBaseReadRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(object id);
    }
}
