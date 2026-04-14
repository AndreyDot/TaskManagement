using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> AddAsync(TaskItem task)
        {
            _context.TaskItems.Add(task);

            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<List<TaskItem>> GetByUserIdAsync(string userId)
        {
            return await _context.TaskItems
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id, string userId)
        {
            return await _context.TaskItems
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }

        public async Task DeleteAsync(TaskItem task)
        {
            _context.TaskItems.Remove(task);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _context.TaskItems.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
