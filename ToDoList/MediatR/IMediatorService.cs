using ToDoList.Models;

namespace ToDoList.MediatR
{
    public interface IMediatorService
    {
        void Notify(DailyPlan dailyPlan);
    }
}
