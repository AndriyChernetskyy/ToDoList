using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.MediatR.Queries
{
    public class GetByPlanIdQueryHandler : IRequestHandler<GetByPlanIdQuery, DailyPlan>
    {
        private readonly IPlannerRepository _plannerRepository;

        public GetByPlanIdQueryHandler(IPlannerRepository plannerRepository)
        {
            _plannerRepository = plannerRepository;
        }

        public async Task<DailyPlan> Handle(GetByPlanIdQuery request, CancellationToken token)
        {
            return await _plannerRepository.GetById(request.Id);
        }
    }
}
