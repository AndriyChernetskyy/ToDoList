using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Persistence.Repositories.Commands;

namespace ToDoList.Commands.Plan.Delete
{
    public class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand>
    {
        private readonly IBaseCommandsRepository<DailyPlan> _baseCommandsRepository;

        public DeletePlanCommandHandler(IBaseCommandsRepository<DailyPlan> baseCommandsRepository)
        {
            _baseCommandsRepository = baseCommandsRepository;
        }

        public async Task<Unit> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
        {
            await _baseCommandsRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
