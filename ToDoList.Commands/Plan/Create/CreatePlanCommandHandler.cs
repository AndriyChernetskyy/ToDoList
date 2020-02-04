using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Persistence.Repositories.Commands;

namespace ToDoList.Commands.Plan.Create
{
    public class CreatePlanCommandHandler: IRequestHandler<CreatePlanCommand>
    {
        private readonly IBaseCommandsRepository<DailyPlan> _baseCommandsRepository;
        
        public CreatePlanCommandHandler(IBaseCommandsRepository<DailyPlan> baseCommandsRepository)
        {
            _baseCommandsRepository = baseCommandsRepository;
        }

        public async Task<Unit> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            await _baseCommandsRepository.Create(
                new DailyPlan
                {
                    DateCreated = DateTime.Now,
                    PlanDescription = request.PlanDescription,
                    DatePlanedFor = request.DatePlanedFor
                });

            return Unit.Value;
        }
    }
}
