using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces.Tasks
{
    public interface ITaskRepository
    {
        Task<TaskItem> AddAsync(TaskItem task);

        Task<List<TaskItem>> GetAllAsync();

        Task<TaskItem?> GetByIdAsync(Guid id);

        Task DeleteAsync(TaskItem task);

        Task UpdateAsync(TaskItem task);

    }
}
