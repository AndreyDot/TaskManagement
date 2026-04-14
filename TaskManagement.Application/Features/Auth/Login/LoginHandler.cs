using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskManagement.Application.Features.Auth.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;

        public LoginHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var findUser = await _userManager.FindByEmailAsync(request.Data.Email);

            if (findUser == null)
            {
                throw new Exception("Invalid credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(findUser, request.Data.Password);

            if (!isPasswordValid)
            {
                throw new Exception("Invalid credentials");
            }

            var token = await _jwtService.GenerateToken(findUser);

            return new AuthResponseDto
            {
                Token = token,
                Email = findUser.Email,
            };
        }
    }
}
