
using System.Security.Claims;

namespace JobOffer.Application.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(User user , List<Claim> authClaims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalTokenFromExpired(string token);
    }
}
