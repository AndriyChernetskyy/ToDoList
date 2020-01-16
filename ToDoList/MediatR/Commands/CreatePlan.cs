using MediatR;
using System;
using ToDoList.Models;

namespace ToDoList.MediatR.Commands
{
    public class CreatePlan : IRequest<DailyPlan>
    {
        public DateTime DatePlanedFor { get; set; }
        public string PlanDescription { get; set; }
    }
}
