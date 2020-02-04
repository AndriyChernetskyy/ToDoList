using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Persistence.Repositories.Commands;

namespace ToDoList.Commands.Plan.Update
{
    public class UpdatePlanCommandHandler: IRequestHandler<UpdatePlanCommand>
    {
        private readonly IBaseCommandsRepository<DailyPlan> _baseCommandsRepository;

        public UpdatePlanCommandHandler(IBaseCommandsRepository<DailyPlan> baseCommandsRepository)
        {
            _baseCommandsRepository = baseCommandsRepository;
        }

        public async Task<Unit> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
        {
            _baseCommandsRepository.Update(
                new DailyPlan 
                { 
                    Id = request.Id, 
                    DatePlanedFor = request.DatePlanedFor, 
                    PlanDescription = request.PlanDescription 
                });

            return Unit.Value;
        }
    }
}
