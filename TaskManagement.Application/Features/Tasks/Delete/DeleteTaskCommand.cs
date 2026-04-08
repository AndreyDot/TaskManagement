using MediatR;

namespace TaskManagement.Application.Features.Tasks.Delete
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}
