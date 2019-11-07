using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDoList.Repository;

namespace ToDoList.MediatR.Commands
{
    public class DeleteDailyPlanCommandHandler : AsyncRequestHandler<DeleteDailyPlanCommand>
    {
        private readonly IPlannerRepository _plannerRepository;
        public DeleteDailyPlanCommandHandler(IPlannerRepository plannerRepository)
        {
            _plannerRepository = plannerRepository;
        }

        protected override async Task Handle(DeleteDailyPlanCommand request, CancellationToken token)
        {
            await _plannerRepository.DeletePlan(request.Id);
        }
    }
}
