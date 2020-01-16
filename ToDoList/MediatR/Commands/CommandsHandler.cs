using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.MediatR.Commands
{
    public class CommandsHandler : IRequestHandler<CreatePlan, DailyPlan>, IRequestHandler<UpdatePlan, DailyPlan>, IRequestHandler<DeletePlan>
    {
        private readonly IPlannerRepository _plannerRepository;

        public CommandsHandler(IPlannerRepository plannerRepository)
        {
            _plannerRepository = plannerRepository;
        }

        public async Task<DailyPlan> Handle(CreatePlan request, CancellationToken cancellationToken)
        {
            var plan = await _plannerRepository.AddPlan(new DailyPlan { DateCreated = DateTime.Now, PlanDescription = request.PlanDescription, DatePlanedFor = request.DatePlanedFor });

            return plan;
        }

        public async Task<DailyPlan> Handle(UpdatePlan request, CancellationToken cancellationToken)
        {
            var plan = await _plannerRepository.UpdatePlan(new DailyPlan { Id = request.Id, DatePlanedFor = request.DatePlanedFor, PlanDescription = request.PlanDescription });

            return plan;
        }

        public async Task<Unit> Handle(DeletePlan request, CancellationToken cancellationToken)
        {
            await _plannerRepository.Delete(request.Id);
            
            return Unit.Value;
        }
    }
}
