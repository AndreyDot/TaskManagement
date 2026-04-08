using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces.Tasks
{
    public interface ITaskRepository
    {
        Task<TaskItem> AddAsync(TaskItem task);

        Task<List<TaskItem>> GetAllAsync();

    }
}
