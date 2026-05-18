
namespace JobOffer.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TypessController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TypessController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpGet]
        [HasPermission(Permissions.Typess.View)]
        public async Task<IActionResult> GetAllType()
        {
            var typies = await _mediator.Send(new GetAllTypies());
            return Ok(typies);
        }





        [HttpGet("{id}")]
        [HasPermission(Permissions.Typess.View)]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var type = await _mediator.Send(new GetTypeById(id));

            if (type == null) return NotFound();

            return Ok(type);
        }




       

        [HttpPost]
        [HasPermission(Permissions.Typess.Create)]
        public async Task<IActionResult> CreateType(CreateType createType)
        {
            var type = await _mediator.Send(createType);
            return Ok(type);
        }





        [HttpPost("{id}")]
        [HasPermission(Permissions.Typess.Update)]
        public async Task<IActionResult> UpdateType(int id, [FromBody] UpdateType updateType)
        {
            if (id != updateType.id) return NotFound();

            var type = await _mediator.Send(updateType);
            return Ok(type);
        }






        [HttpDelete("{id}")]
        [HasPermission(Permissions.Typess.Delete)]
        public async Task<IActionResult> DeleteType(int id)
        {

            var type = await _mediator.Send(new DeleteType(id));
            return Ok(type);

        }

    }
}
