using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class PlannerRepository : IPlannerRepository
    {
        private readonly PlannerContext _context;

        public PlannerRepository(PlannerContext context)
        {
            _context = context;
        }

        public void CreatePlan(DailyPlan dailyPlan)
        {
            _context.Planners.Add(dailyPlan);
        }

        public bool Delete(int id)
        {   
            var removed = false;
            var planToRemove = GetById(id);
            if (planToRemove != null)
            {
                _context.Planners.Remove(planToRemove);
                removed = true;
            }

            return removed;
        }

        public IQueryable<DailyPlan> GetAll()
        {
            return _context.Planners.AsNoTracking();
        }

        public DailyPlan GetById(int id)
        {
            return _context.Planners.FirstOrDefault(pl => pl.Id == id);
        }
    }
}
