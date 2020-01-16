using MediatR;
using System;
using ToDoList.Models;

namespace ToDoList.MediatR.Commands
{
    public class UpdatePlan : IRequest<DailyPlan>
    {
        public int Id;
        public DateTime DatePlanedFor { get; set; }
        public string PlanDescription { get; set; }
    }
}
