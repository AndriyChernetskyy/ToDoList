using MediatR;
using System;
using ToDoList.Models;

namespace ToDoList.Commands.Plan.Create
{
    public class CreatePlanCommand : IRequest
    {
        public DateTime DatePlanedFor { get; set; }
        public string PlanDescription { get; set; }
    }
}
