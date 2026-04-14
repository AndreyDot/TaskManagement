using MediatR;
using TaskManagement.Application.Interfaces.Tasks;

namespace TaskManagement.Application.Features.Tasks.Delete
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id, request.UserId);

            if (task == null)
            {
                throw new KeyNotFoundException("Task not found");
            }

            await _taskRepository.DeleteAsync(task);

            return Unit.Value;
        }
    }
}
