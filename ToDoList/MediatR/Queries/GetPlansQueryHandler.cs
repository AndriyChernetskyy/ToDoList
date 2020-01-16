using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.MediatR.Queries
{
    public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, IEnumerable<DailyPlan>>
    {
        private readonly IPlannerRepository _plannerRepository;

        public GetPlansQueryHandler(IPlannerRepository plannerRepository)
        {
            _plannerRepository = plannerRepository;
        }

        public async Task<IEnumerable<DailyPlan>> Handle(GetPlansQuery request, CancellationToken token)
        {
            var result = await _plannerRepository.GetAll();
            return result;
        }
    }
}
