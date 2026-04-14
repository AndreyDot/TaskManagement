using MediatR;

namespace TaskManagement.Application.Features.Tasks.Delete
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string UserId { get; }
        public bool IsAdmin { get; }
        public DeleteTaskCommand(Guid id, string userId, bool isAdmin)
        {
            Id = id;
            UserId = userId;
            IsAdmin = isAdmin;
        }
    }
}
