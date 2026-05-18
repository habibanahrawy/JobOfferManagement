namespace JobOffer.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoginsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LoginsController(IMediator mediator)
        {
            _mediator = mediator;
        }

 

        // Login
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




        // Forget Pass

        [HttpPost("ForgetPassWord")]
        public async Task<IActionResult> forgetpassword(string email)
        {
            var result = await _mediator.Send(new ForgetPass(email));
            return Ok();

        }




        // Reset Pass

        [HttpPost("ResetPassWord")]
        public async Task<IActionResult> Resetpassword([FromBody] ResetPassDTO passDTO)
        {
            var result = await _mediator.Send(new ResetPass(passDTO));
            return Ok("Password Reseted!");
        }


        // Refresh Token

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> Refreshtoken([FromBody] RefreshTokenDTO tokenDTO)
        {
            var result = await _mediator.Send(new RefreshToken(tokenDTO));
            if(result == null) return Unauthorized();
            return Ok(result);
        }

    }
}
