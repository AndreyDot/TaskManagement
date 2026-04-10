using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskManagement.Application.Features.Auth.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;

        public RegisterHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var user = new ApplicationUser
            {
                Email = request.Data.Email,
                UserName = request.Data.Email
            };

            var result = await _userManager.CreateAsync(user, request.Data.Password);

            if (!result.Succeeded) 
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception(errors);
            }

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto 
            { 
                Token = token,
                Email = user.Email,
            };
        }
    }
}
