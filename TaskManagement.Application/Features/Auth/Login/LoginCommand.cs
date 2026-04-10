using MediatR;
using TaskManagement.Application.Features.Auth.DTOs;

namespace TaskManagement.Application.Features.Auth.Login
{
    public class LoginCommand: IRequest<AuthResponseDto>
    {
        public LoginDto Data { get; }

        public LoginCommand(LoginDto data)
        {
            Data = data;
        }
    }
}
