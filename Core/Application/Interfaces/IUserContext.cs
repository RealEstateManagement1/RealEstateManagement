using System.Security.Claims;

namespace Application.Interfaces
{
    public interface IUserContext
    {
        ClaimsPrincipal ClaimsPrincipal { get; }
        int? UserId { get; }
        string Email { get; }
        string FullName { get; }
        bool IsAuthenticated { get; }
        string GetClaim(string claimType);
    }
}
