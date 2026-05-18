
namespace JobOffer.Application.Services.Account.Handlers
{
    public class RefreshTokenHandler : IRequestHandler<RefreshToken, AuthDTO>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RefreshTokenHandler(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthDTO> Handle(RefreshToken request, CancellationToken cancellationToken)
        {
            var principal = _tokenService.GetPrincipalTokenFromExpired(request.TokenDTO.Token);
            if (principal == null) return null;

            var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(email!);

            if (user == null || user.RefreshToken != request.TokenDTO.RefreshToken || user.ExpiredTimeToken <= DateTime.UtcNow)
            {
                return null!;
            }

            var newAccessToken = await _tokenService.CreateTokenAsync(user, principal.Claims.ToList());
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.ExpiredTimeToken = DateTime.UtcNow.AddDays(7); 

            await _userManager.UpdateAsync(user);

            return new AuthDTO
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken,
                ExpiredTime = user.ExpiredTimeToken.Value
            };
        }
    }
}