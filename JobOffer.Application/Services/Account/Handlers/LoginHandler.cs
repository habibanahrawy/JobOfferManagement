
namespace JobOffer.Application.Services.Account.Handlers
{
    public class LoginHandler : IRequestHandler<Login, AuthDTO>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public LoginHandler(UserManager<User> userManager,
                            SignInManager<User> signInManager,
                            RoleManager<IdentityRole> roleManager,
                            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task<AuthDTO> Handle(Login request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.LoginDTO.Email);
            if (user == null) return null!;

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.LoginDTO.Password, false);
            if (!result.Succeeded) return null!;

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var roleName in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, roleName));

                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);

                    authClaims.AddRange(roleClaims);
                }
            }

            var accessToken = await _tokenService.CreateTokenAsync(user, authClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.ExpiredTimeToken = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);

            return new AuthDTO
            {
                Token = accessToken,
                RefreshToken = refreshToken,
                ExpiredTime = user.ExpiredTimeToken.Value
            };
        }
    }
}