using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTaskByIdQuery(id));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {

                DeleteTaskCommand command = new DeleteTaskCommand(id);

                await _mediator.Send(command);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskDto>> Update([FromRoute]Guid id, [FromBody]UpdateTaskDto dto)
        {
            var command = new UpdateTaskCommand(id, dto);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
