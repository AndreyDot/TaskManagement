using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.GetById
{
    public class GetTaskByIdQuery: IRequest<TaskDto>
    {
        public Guid Id { get; set; }
        public string UserId { get; }
        public bool IsAdmin { get; }

        public GetTaskByIdQuery(Guid id, string userId, bool isAdmin)
        {
            Id = id;
            UserId = userId;
            IsAdmin = isAdmin;
        }
    }
}
