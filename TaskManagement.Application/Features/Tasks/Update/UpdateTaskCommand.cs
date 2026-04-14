using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.Update
{
    public class UpdateTaskCommand: IRequest<TaskDto>
    {
        public Guid Id { get; set; }
        public UpdateTaskDto UpdateData { get; set; }
        public string UserId { get; }
        public bool IsAdmin { get; set; }

        public UpdateTaskCommand(Guid id, UpdateTaskDto updateData, string userId, bool isAdmin)
        {
            Id = id;
            UpdateData = updateData;
            UserId = userId;
            IsAdmin = isAdmin;
        }

    }
}
