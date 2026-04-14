using AutoMapper;
using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Interfaces.Tasks;

namespace TaskManagement.Application.Features.Tasks.GetAll
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, List<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetAllTasksHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync();

            if (request.IsAdmin)
            {
                return _mapper.Map<List<TaskDto>>(tasks);
            }

            var userTasks = tasks
                .Where(x => x.UserId == request.UserId)
                .ToList();

            return _mapper.Map<List<TaskDto>>(userTasks);
        }

    }
}
