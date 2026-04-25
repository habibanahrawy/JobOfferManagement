namespace JobOffer.Application.Services.Account.Handlers
{
    public class LoginHandler : IRequestHandler<Login, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;   

        public LoginHandler(UserManager<User> userManager , SignInManager<User> signInManager , ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<string> Handle(Login request, CancellationToken cancellationToken)
        {
            var user =await _userManager.FindByEmailAsync(request.LoginDTO.Email);
            if (user == null) return null;

            var result =await _signInManager.CheckPasswordSignInAsync(user, request.LoginDTO.Password, false);

            if (!result.Succeeded) return null;

            return await _tokenService.CreateTokenAsync(user);
        }
    }
}
