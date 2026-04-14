

namespace JobOffer.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _mediator.Send(new GetAllCities());
            return Ok(cities);
        }





        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _mediator.Send(new GetCityById(id));

            if (city == null) return NotFound();

            return Ok(city);
        }




        // Admin

        [HttpPost]
        public async Task<IActionResult> CreateCity(CreateCity createCity)
        {
            var city = await _mediator.Send(createCity);
            return Ok(city);
        }





        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] UpdateCity updateCity)
        {
            if (id != updateCity.id) return NotFound();

            var city = await _mediator.Send(updateCity);
            return Ok(city);
        }






        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {

            var city = await _mediator.Send(new DeleteCity(id));
            return Ok(city);

        }




    }
}
