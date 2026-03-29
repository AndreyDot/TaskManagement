using AutoMapper;
using TaskManagement.Domain.Entities;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Mappings
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskItem, TaskDto>().ReverseMap();
            CreateMap<CreateTaskDto, TaskItem>();
        }
    }
}