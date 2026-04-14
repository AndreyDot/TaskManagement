using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces.Tasks
{
    public interface ITaskRepository
    {
        Task<TaskItem> AddAsync(TaskItem task);

        Task<List<TaskItem>> GetAllAsync();

        Task<List<TaskItem>> GetByUserIdAsync(string userId);

        Task<TaskItem?> GetByIdAsync(Guid id, string userId);

        Task DeleteAsync(TaskItem task);

        Task UpdateAsync(TaskItem task);

    }
}
