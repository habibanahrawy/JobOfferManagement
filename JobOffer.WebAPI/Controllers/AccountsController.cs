using JobOffer.Application.DTOs;
using JobOffer.Application.Services.Account.Commands;

namespace JobOffer.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> register([FromForm] RegisterDTO registerDTO)
        {
            var result = await _mediator.Send(new Register(registerDTO));
            return Ok(result);
        }



        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginDTO loginDTO)
        {
            var result = await _mediator.Send(new Login(loginDTO));
            if (result == null) return BadRequest("Invalid Email Or Password");
            return Ok(new
            {
                User = loginDTO.Email,
                token = result
            });
        }
    }
}
