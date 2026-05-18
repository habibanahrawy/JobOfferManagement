using JobOffer.Core.Enums;

namespace JobOffer.Infrastructure.DataSeed
{
    public class RoleSeed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public RoleSeed(UserManager<User> userManager,
                        RoleManager<IdentityRole> roleManager,
                        IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task Seeding()
        {
            try
            {
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }

                await CreateUserFromConfig("AdminUser", "Admin");
                await CreateUserFromConfig("SuperAdminUser", "SuperAdmin");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding Error: {ex.Message}");
            }
        }

        private async Task CreateUserFromConfig(string configSection, string roleName)
        {
            var userEmail = _configuration[$"{configSection}:Email"];

            if (string.IsNullOrEmpty(userEmail)) return;

            var existingUser = await _userManager.FindByEmailAsync(userEmail);

            if (existingUser == null)
            {
                var user = new User
                {
                    FullName = _configuration[$"{configSection}:FullName"],
                    UserName = _configuration[$"{configSection}:UserName"],
                    Email = userEmail,
                    CityId = int.Parse(_configuration[$"{configSection}:CityId"] ?? "1"),
                    CVFile = _configuration[$"{configSection}:CVFile"],
                    Gender = _configuration[$"{configSection}:Gender"] == "Gender.Female" ? Gender.Female : Gender.Male,
                    RefreshToken = string.Empty,
                    ExpiredTimeToken = DateTime.UtcNow
                };

                var password = _configuration[$"{configSection}:Password"] ?? "P@ssword123";

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"User Creation Error: {error.Description}");
                    }
                }
            }
        }
    }
}