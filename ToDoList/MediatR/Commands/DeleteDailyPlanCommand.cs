using MediatR;

namespace ToDoList.MediatR.Commands
{
    public class DeleteDailyPlanCommand : IRequest
    {
        public int Id { get; set; }
    }
}
