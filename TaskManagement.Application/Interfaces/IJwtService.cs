using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(ApplicationUser user);
    }
}
