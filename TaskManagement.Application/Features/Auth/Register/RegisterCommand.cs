using MediatR;
using TaskManagement.Application.Features.Auth.DTOs;

namespace TaskManagement.Application.Features.Auth.Register
{
    public class RegisterCommand: IRequest<AuthResponseDto>
    {
        public RegisterDto Data { get; }

        public RegisterCommand(RegisterDto data)
        {
            Data = data;
        }
    }
}
