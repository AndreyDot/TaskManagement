using AutoMapper;
using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Interfaces.Tasks;

namespace TaskManagement.Application.Features.Tasks.Update
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);

            if (task == null) 
            {
                throw new KeyNotFoundException("Task not found");
            }

            task.Title = request.UpdateData.Title;
            task.Description = request.UpdateData.Description;
            task.Priority = request.UpdateData.Priority;
            task.Status = request.UpdateData.Status;

            await _taskRepository.UpdateAsync(task);

            var taskDto = _mapper.Map<TaskDto>(task);

            return taskDto;

        }
    }
}
