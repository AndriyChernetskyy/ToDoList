using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Persistence.Repositories.Commands
{
    public class BaseCommandsRepository<T> : IBaseCommandsRepository<T> where T : class
    {
        private readonly PlannerContext _context;
        private readonly DbSet<T> DbSet = null;

        public BaseCommandsRepository(PlannerContext context)
        {
            DbSet = context.Set<T>();
        }

        public async Task Create(T obj)
        {
            await DbSet.AddAsync(obj);
        }

        public async Task Delete(object id)
        {
            T existing = await DbSet.FindAsync(id);

            if (existing == null)
            {
                throw new ArgumentException("Current id does not exist");
            }

            DbSet.Remove(existing);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T obj)
        {
            Task.Run(() =>
            {
                DbSet.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
            });
        }
    }
}
