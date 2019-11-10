using MediatR;
using System.Threading.Tasks;
using ToDoList.MediatR.Queries;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList
{
    public class PlannerService : IPlannerService
    {
        private readonly IMediator _mediatr;
        
        public PlannerService(IMediator mediator)
        {
            _mediatr = mediator;
        }

        public async Task<DailyPlan> Notify(int id)
        {
            return await _mediatr.Send(new GetByPlanIdQuery { Id = id });
        }
    }
}
