using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public interface IPlannerRepository
    {
        IQueryable<DailyPlan> GetAll();
        DailyPlan GetById(int id);
        void CreatePlan(DailyPlan dailyPlan);
        bool Delete(int id);
    }
}
