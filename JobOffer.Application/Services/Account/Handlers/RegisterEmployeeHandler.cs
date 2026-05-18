
namespace JobOffer.Application.Services.Account.Handlers
{
    public class RegisterEmployeeHandler : IRequestHandler<RegisterEmployee, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterEmployeeHandler(UserManager<User> userManager , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(RegisterEmployee request, CancellationToken cancellationToken)
        {
            var dto = request.employeeDTO;

            var employee = new User
            {
                FullName = dto.FullName,
                UserName = dto.UserName,
                Email = dto.Email,
                CityId = dto.CityId,
                Gender = dto.Gender,
                CVFile = null
            };

            var result = await _userManager.CreateAsync(employee, dto.Password);

            if (!await _roleManager.RoleExistsAsync("Employee"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
            }

            await _userManager.AddToRoleAsync(employee, "Employee");

            return true;

        }
    }
}
