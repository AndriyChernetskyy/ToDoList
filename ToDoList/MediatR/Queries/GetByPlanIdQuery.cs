using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.MediatR.Queries
{
    public class GetByPlanIdQuery : IRequest<DailyPlan>
    {
        public int Id { get; set; }
    }
}
