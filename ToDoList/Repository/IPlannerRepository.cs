using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public interface IPlannerRepository
    {
        Task<IQueryable<DailyPlan>> GetAll();
        Task<DailyPlan> GetById(int id); 
        Task AddPlan(DailyPlan dailyPlan);
        Task DeletePlan(int id);
        Task UpdatePlan(int id, DailyPlan plan);
    }
}
