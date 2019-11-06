using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.MediatR
{
    public class MediatorService
    {
        private readonly IMediator _mediator;
        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void Notify(DailyPlan dailyPlan)
        {
            _mediator.Publish(dailyPlan);
        }
    }
}
