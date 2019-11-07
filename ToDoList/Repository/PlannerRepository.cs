using System.Linq;
using System.Threading.Tasks;
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

        public async Task AddPlan(DailyPlan dailyPlan)
        {
            var state = await _context.Planners.AddAsync(dailyPlan);
            if (state.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePlan(int id, DailyPlan dailyPlan)
        {
            var request = await _context.Planners.SingleAsync(r => r.Id == id);

            request = dailyPlan;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePlan(int id)
        {   
            var planToRemove = await GetById(id);
            if (planToRemove != null)
            {
                _context.Planners.Remove(planToRemove);
            }

            await _context.SaveChangesAsync();

        }

        public async Task<IQueryable<DailyPlan>> GetAll()
        {
            return _context.Planners.AsNoTracking();
        }

        public async Task<DailyPlan> GetById(int id)
        {
            return await _context.Planners.FirstOrDefaultAsync(pl => pl.Id == id);
        }
    }
}
