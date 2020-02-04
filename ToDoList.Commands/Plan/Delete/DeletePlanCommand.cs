using MediatR;

namespace ToDoList.Commands.Plan.Delete
{
    public class DeletePlanCommand : IRequest
    {
        public int Id;
    }
}
