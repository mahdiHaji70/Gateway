using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TDM.Application.Common.Interfaces;

namespace TDM.Infrastructure.Persistence
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public string? UserId =>
            User?.FindFirst("sub")?.Value;

        public string? NationalId =>
            User?.FindFirst("nationalId")?.Value;

        public string? Email =>
            User?.FindFirst("email")?.Value;

        public string? FirstName =>
            User?.FindFirst("firstName")?.Value;

        public bool IsAuthenticated =>
            User?.Identity?.IsAuthenticated ?? false;
    }
}
