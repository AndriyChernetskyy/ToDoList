using MediatR;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Queries.Plan.Get
{
    public class GetPlansQuery : IRequest<IEnumerable<DailyPlan>>
    {
    }
}
