using MediatR;

namespace ToDoList.MediatR.Commands
{
    public class DeletePlan : IRequest
    {
        public int Id;
    }
}
