
namespace JobOffer.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersManagmentController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMediator _mediator;

        public UsersManagmentController(UserManager<User> userManager , RoleManager<IdentityRole> roleManager , IMediator mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mediator = mediator;
        }


     


        // get 

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            return Ok(users);
        }


        // add

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(string UserId , string role)
        {

            var user = await _userManager.FindByIdAsync(UserId);

            var rollle = await _roleManager.RoleExistsAsync(role);

            if (user == null || rollle == null) return null;

            await _userManager.AddToRoleAsync(user , role);

            return Ok("Role Assigned To User");

        }


        // deleteUser
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string UserId)
        {

            var user =await _userManager.FindByIdAsync(UserId);
            if (user == null) return NotFound("User Not Found");

            var result = await _userManager.DeleteAsync(user);

            return Ok("User Delete!");
        }


        // delete Role From User

        [HttpPost("RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRole(string UserId , string role)
        {

            var user = await _userManager.FindByIdAsync(UserId);

            if (user == null) return NotFound("User Not Found");

            var result = await _userManager.RemoveFromRoleAsync(user, role);

            return Ok("Role Remove From User");
        }


    }
}
