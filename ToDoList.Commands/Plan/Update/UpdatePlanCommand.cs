using MediatR;
using System;
using ToDoList.Models;

namespace ToDoList.Commands.Plan.Update
{
    public class UpdatePlanCommand : IRequest
    {
        public int Id;
        public DateTime DatePlanedFor { get; set; }
        public string PlanDescription { get; set; }
    }
}
