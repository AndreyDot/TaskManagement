using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagement.Application.Features.Tasks.Create;
using TaskManagement.Application.Features.Tasks.Delete;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Features.Tasks.GetAll;
using TaskManagement.Application.Features.Tasks.GetById;
using TaskManagement.Application.Features.Tasks.Update;

namespace TaskManagement.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> Create(CreateTaskDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var command = new CreateTaskCommand(dto, userId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var isAdmin = User.IsInRole("Admin");

            var result = await _mediator.Send(new GetAllTasksQuery(userId, isAdmin));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetById(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var isAdmin = User.IsInRole("Admin");

            var result = await _mediator.Send(new GetTaskByIdQuery(id, userId, isAdmin));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var isAdmin = User.IsInRole("Admin");

            await _mediator.Send(new DeleteTaskCommand(id, userId, isAdmin));

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskDto>> Update([FromRoute]Guid id, [FromBody]UpdateTaskDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var isAdmin = User.IsInRole("Admin");

            var command = new UpdateTaskCommand(id, dto, userId, isAdmin);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
