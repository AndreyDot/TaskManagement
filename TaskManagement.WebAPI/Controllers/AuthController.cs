using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Auth.DTOs;
using TaskManagement.Application.Features.Auth.Register;

namespace TaskManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto dto)
        {
            var command = new RegisterCommand(dto);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
