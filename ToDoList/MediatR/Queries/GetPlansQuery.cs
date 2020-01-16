using MediatR;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.MediatR.Queries
{
    public class GetPlansQuery : IRequest<IEnumerable<DailyPlan>>
    {
    }
}
