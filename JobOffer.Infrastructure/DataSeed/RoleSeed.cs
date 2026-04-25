
using JobOffer.Core.Enums;

namespace JobOffer.Infrastructure.DataSeed
{
    public class RoleSeed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleSeed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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

                if (await _userManager.FindByEmailAsync("habibamoh@gmail.com") == null)
                {
                    var user01 = new User
                    {
                        FullName = "Habiba MohNahr",
                        Gender = Gender.Female,
                        UserName = "habibamohnahr",
                        Email = "habibamoh@gmail.com",
                        CityId = 1,
                        CVFile = "cv.pdf"
                    };

                    var user02 = new User
                    {
                        FullName = "Marya Fayed",
                        UserName = "maryafayed",
                        Gender = Gender.Female,
                        Email = "maryafayed@gmail.com",
                        CityId = 1,
                        CVFile = "cv.pdf"
                    };


                    await _userManager.CreateAsync(user01, "P@ssw0rd123");
                    await _userManager.CreateAsync(user02, "P@ssw0rd123");


                    await _userManager.AddToRoleAsync(user01, "Admin");
                    await _userManager.AddToRoleAsync(user02, "SuperAdmin");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}