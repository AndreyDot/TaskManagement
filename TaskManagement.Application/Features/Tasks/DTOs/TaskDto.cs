using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Features.Tasks.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public TaskItemStatus Status { get; set; }  

        public TaskPriority Priority { get; set; }

        public DateTime CreatedAt { get; set; } 

    }
}
