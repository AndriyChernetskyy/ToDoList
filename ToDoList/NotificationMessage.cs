using System;
using MediatR;

namespace ToDoList
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
}
