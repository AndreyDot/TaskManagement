using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Services
{
    public class JwtService: IJwtService
    {
        public string GenerateToken(ApplicationUser user)
        {
            return "Token";
        }
    }
}
