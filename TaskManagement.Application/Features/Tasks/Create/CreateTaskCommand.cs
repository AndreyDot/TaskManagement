using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.Create
{
    public class CreateTaskCommand: IRequest<TaskDto>
    {
        public CreateTaskDto TaskData { get; }

        public string UserId { get; }

        public CreateTaskCommand(CreateTaskDto task, string userId)
        {
            TaskData = task;
            UserId = userId;
        }
    }
}
