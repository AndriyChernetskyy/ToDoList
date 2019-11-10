using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IPlannerService
    {
        Task<DailyPlan> Notify(int id);
    }
}
