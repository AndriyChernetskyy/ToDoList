using System;
using System.Collections.Generic;
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

        public async Task<DailyPlan> AddPlan(DailyPlan dailyPlan)
        {
            var state = await _context.Planners.AddAsync(dailyPlan);
            if (state.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();
            }
            return dailyPlan;
        }

        public async Task<DailyPlan> UpdatePlan(DailyPlan dailyPlan)
        {
            var request = await _context.Planners.SingleAsync(r => r.Id == dailyPlan.Id);

            request.DatePlanedFor = dailyPlan.DatePlanedFor != null ? dailyPlan.DatePlanedFor : request.DatePlanedFor;
            request.PlanDescription = dailyPlan.PlanDescription != null ? dailyPlan.PlanDescription : request.PlanDescription;
            
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<IEnumerable<DailyPlan>> GetAll()
        {
            return _context.Planners;
        }

        public async Task Delete(int id)
        {
            var plan = await _context.Planners.SingleOrDefaultAsync(p => p.Id == id);

            if (plan != null)
            {
                throw new Exception("There is no such a plan");            
            }
            _context.Planners.Remove(plan);
            await _context.SaveChangesAsync();
        }
   }
}
