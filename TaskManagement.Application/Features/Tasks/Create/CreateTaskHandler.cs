using AutoMapper;
using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Interfaces.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Tasks.Create
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
        {
            var taskItem = _mapper.Map<TaskItem>(command.TaskData);

            taskItem.UserId = command.UserId;
            taskItem.CreatedAt = DateTime.UtcNow;

            var createdTask = await _taskRepository.AddAsync(taskItem);

            return _mapper.Map<TaskDto>(createdTask);
        }
    }
}
