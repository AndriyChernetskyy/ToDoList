using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace ToDoList
{
    public class NotifierMediatorService : INotifierMediatorService
    {
        private readonly IMediator _mediator;
        public NotifierMediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void Notify(string notifyText)
        {
            _mediator.Publish(new NotificationMessage
            {
                NotifyText = notifyText
            });
        }
    }
}
