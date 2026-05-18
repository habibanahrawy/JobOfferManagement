
namespace JobOffer.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistersController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost("RegisterUser")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterDTO registerDTO)
        {
            var result = await _mediator.Send(new Register(registerDTO));
            return Ok(result);
        }




        [HttpPost("RegisterEmployee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] EmployeeDTO dto)
        {
            var result = await _mediator.Send(new RegisterEmployee(dto));
            if (result) return Ok("Employee Registered Successfully as HR!");
            return BadRequest("Registration Failed");
        }
    }
}

