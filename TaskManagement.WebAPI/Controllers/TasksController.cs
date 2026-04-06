using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Tasks.Create;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController: ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskDto dto)
        {
            CreateTaskCommand command = new CreateTaskCommand(dto);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
