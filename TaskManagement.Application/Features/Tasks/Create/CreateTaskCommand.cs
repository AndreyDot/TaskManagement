using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.Create
{
    public class CreateTaskCommand: IRequest<TaskDto>
    {
        public CreateTaskDto TaskData { get; }

        public CreateTaskCommand(CreateTaskDto task)
        {
            TaskData = task;
        }
    }
}
