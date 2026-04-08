using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Tasks.Create;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Features.Tasks.GetAll;

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
        public async Task<ActionResult<TaskDto>> Create([FromBody] CreateTaskDto dto)
        {
            CreateTaskCommand command = new CreateTaskCommand(dto);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllTasksQuery());

            return Ok(result);
        }
    }
}
