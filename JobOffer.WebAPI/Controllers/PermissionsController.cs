using System.Security.Claims;

namespace JobOffer.WebAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public PermissionsController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        // GetAll 

        [HttpGet("GetAllPermissions")]

        public IActionResult GetAllPermissions()
        {
            var permissions = Permissions.GetAllPermissions();

            if (permissions == null) return null;

            return Ok(permissions);
        }



        // Create 

        [HttpPost("CreatePermissions")]
        public async Task<IActionResult> CreatePermissions([FromBody] PermissionDTO dTO)
        {

            var role = await _roleManager.FindByIdAsync(dTO.RoleId);

            if (role == null) return NotFound();

            var claims = await _roleManager.GetClaimsAsync(role);

            foreach (var permission in dTO.permissions)
            {
                var perExist = claims.Any(P => P.Type == "Permission" && P.Value == permission);

                if (!perExist)
                {
                    await _roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
            return Ok("Permission Is Created");
        }



        // Update

        [HttpPost("update-permissions")]
        public async Task<IActionResult> UpdateRolePermissions(PermissionDTO dto)
        {
            var role = await _roleManager.FindByIdAsync(dto.RoleId);
            if (role == null) return NotFound("Role not found");

            var existingClaims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in existingClaims.Where(c => c.Type == "Permission"))
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }

            foreach (var permission in dto.permissions)
            {
                await _roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }

            return Ok("Permissions updated successfully");
        }



        // Delete

        [HttpDelete("DeletePermission")]

        public async Task<IActionResult> DetelePermission([FromBody] PermissionDTO dTO)
        {

            var role = await _roleManager.FindByIdAsync(dTO.RoleId);
            if (role == null) return NotFound();

            var claims = await _roleManager.GetClaimsAsync(role);

            foreach (var permisn in dTO.permissions)
            {
                var claimToDelete = claims.FirstOrDefault(c => c.Type == "Permission" && c.Value == permisn);
                if (claimToDelete != null)
                {
                    await _roleManager.RemoveClaimAsync(role, claimToDelete);
                }
            }
            return Ok("permission Is Deleted");
        }
    }
}
