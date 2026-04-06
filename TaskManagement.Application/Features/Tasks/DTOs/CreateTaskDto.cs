using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Features.Tasks.DTOs
{
    public class CreateTaskDto
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public TaskPriority Priority { get; set; }

    }
}
