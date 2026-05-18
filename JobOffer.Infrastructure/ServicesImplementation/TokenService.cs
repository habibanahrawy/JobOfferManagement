using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JobOffer.Infrastructure.ServicesImplementation
{
    public class TokenService : ITokenService
    {

        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public TokenService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(User user, List<Claim> authClaims)
        {
            var secretKey = _configuration["JWTOptions:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(
                issuer: _configuration["JWTOptions:Issuer"],
                audience: _configuration["JWTOptions:Audience"],
                expires: DateTime.UtcNow.AddHours(1),
                claims: authClaims,
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        public string GenerateRefreshToken()
        {
            var num = new byte[64];
            using var randomnum = RandomNumberGenerator.Create();
            randomnum.GetBytes(num);
            return Convert.ToBase64String(num);

        }



        public ClaimsPrincipal GetPrincipalTokenFromExpired(string token)
        {
            var tokenValidation = new TokenValidationParameters
            {
                ValidateAudience = false, 
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTOptions:SecretKey"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidation, out SecurityToken securityToken);

            return principal;
        }
    }
    
}
