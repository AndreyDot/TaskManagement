using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.GetAll
{
    public class GetAllTasksQuery: IRequest<List<TaskDto>>
    {
        public string UserId { get; }

        public GetAllTasksQuery(string userId)
        {
            UserId = userId;
        }
    }
}
