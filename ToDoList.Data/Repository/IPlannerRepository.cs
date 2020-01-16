using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public interface IPlannerRepository
    {
        Task<IEnumerable<DailyPlan>> GetAll();
        Task<DailyPlan> AddPlan(DailyPlan dailyPlan);
        Task<DailyPlan> UpdatePlan(DailyPlan plan);
        Task Delete(int id);
    }
}
