using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Persistence.Repositories.Queries
{
    public class BaseReadRepository<T> : IBaseReadRepository<T> where T : class
    {
        private readonly DbSet<T> DbSet = null;

        public BaseReadRepository(PlannerContext context)
        {
            DbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public async Task<T> GetById(object id)
        {
            return await DbSet.FindAsync(id);
            
        }
    }
}
