
namespace JobOffer.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // getall

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            if (roles == null) return NotFound("No Roles Found");

            return Ok(roles);

        }

        // add

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody]string role)
        {
            if (string.IsNullOrEmpty(role))
                return null;

            var roleExist = await _roleManager.RoleExistsAsync(role);

            if (roleExist) return NotFound("Role Exist");


            var result = await _roleManager.CreateAsync(new IdentityRole(role));

            return Ok("Role Add Success");

        }

        // delete
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromBody]string role)
        {
            var isExist =await _roleManager.FindByNameAsync(role);

            if (isExist == null) return NotFound("Role Not Found");

            var result = await _roleManager.DeleteAsync(isExist);

            return Ok("Role Is Delete");

        }


    }
}
