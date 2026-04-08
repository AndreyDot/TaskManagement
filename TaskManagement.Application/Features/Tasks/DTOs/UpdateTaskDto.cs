using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Features.Tasks.DTOs
{
    public class UpdateTaskDto
    {
        public string Title { get; set; }

        public string? Description { get; set; }
        
        public TaskPriority Priority { get; set; }

        public TaskItemStatus Status { get; set; }

    }
}
