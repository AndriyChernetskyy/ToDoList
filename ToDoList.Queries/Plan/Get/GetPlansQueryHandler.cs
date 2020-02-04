using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Persistence.Repositories.Queries;

namespace ToDoList.Queries.Plan.Get
{
    public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, IEnumerable<DailyPlan>>
    {
        private readonly IBaseReadRepository<DailyPlan> _baseReadRepository;

        public GetPlansQueryHandler(IBaseReadRepository<DailyPlan> baseReadRepository)
        {
            _baseReadRepository = baseReadRepository;
        }

        public async Task<IEnumerable<DailyPlan>> Handle(GetPlansQuery request, CancellationToken token)
        {
            var result = await _baseReadRepository.GetAll().ToListAsync();
            
            return result;
        }
    }
}
