
namespace JobOffer.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {


        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpGet]
        [HasPermission(Permissions.Countries.View)]
        public async Task<IActionResult> GetAllCountry()
        {
            var countries = await _mediator.Send(new GetAllCountries());
            return Ok(countries);
        }





        [HttpGet("{id}")]
        [HasPermission(Permissions.Countries.View)]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var country = await _mediator.Send(new GetCountryById(id));

            if (country == null) return NotFound();

            return Ok(country);
        }




        

        [HttpPost]
        [HasPermission(Permissions.Countries.Create)]
        public async Task<IActionResult> CreateCountry(CreateCountry createCountry)
        {
            var country = await _mediator.Send(createCountry);
            return Ok(country);
        }





        [HttpPost("{id}")]
        [HasPermission(Permissions.Countries.Update)]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] UpdateCountry updateCountry)
        {
            if (id != updateCountry.id) return NotFound();

            var country = await _mediator.Send(updateCountry);
            return Ok(country);
        }






        [HttpDelete("{id}")]
        [HasPermission(Permissions.Countries.Delete)]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _mediator.Send(new DeleteCategory(id));
            return Ok(country);

        }
    }
}
