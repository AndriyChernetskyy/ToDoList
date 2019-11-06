using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlannerContext _context;

        public IPlannerRepository PlannerRepository { get; }

        public UnitOfWork(PlannerContext context)
        {
            _context = context;
            PlannerRepository = new PlannerRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
