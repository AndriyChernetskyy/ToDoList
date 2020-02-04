using System.Threading.Tasks;

namespace ToDoList.Persistence.Repositories.Commands
{
    public interface IBaseCommandsRepository<T> where T : class
    {
        Task Create(T obj);
        void Update(T obj);
        Task Delete(object id);
        Task Save();
    }
}
