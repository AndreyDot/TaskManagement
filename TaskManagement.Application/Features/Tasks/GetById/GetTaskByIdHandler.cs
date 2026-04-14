using AutoMapper;
using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Interfaces.Tasks;

namespace TaskManagement.Application.Features.Tasks.GetById
{
    public class GetTaskByIdHandler: IRequestHandler<GetTaskByIdQuery, TaskDto>
    {
        private ITaskRepository _taskRepository;
        private IMapper _mapper;

        public GetTaskByIdHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);

            if (task == null)
                throw new KeyNotFoundException();

            if (!request.IsAdmin && task.UserId != request.UserId)
                throw new UnauthorizedAccessException();

            return _mapper.Map<TaskDto>(task);
        }
    }
}
