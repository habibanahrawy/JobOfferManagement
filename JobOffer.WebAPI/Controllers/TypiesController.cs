using JobOffer.Application.Features.Categories.Commands;
using JobOffer.Application.Features.Categories.Queries;
using JobOffer.Application.Features.Typies.Commands;
using JobOffer.Application.Features.Typies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffer.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TypiesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TypiesController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllType()
        {
            var typies = await _mediator.Send(new GetAllTypies());
            return Ok(typies);
        }





        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var type = await _mediator.Send(new GetTypeById(id));

            if (type == null) return NotFound();

            return Ok(type);
        }




        // Admin

        [HttpPost]
        public async Task<IActionResult> CreateType(CreateType createType)
        {
            var type = await _mediator.Send(createType);
            return Ok(type);
        }





        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateType(int id, [FromBody] UpdateType updateType)
        {
            if (id != updateType.id) return NotFound();

            var type = await _mediator.Send(updateType);
            return Ok(type);
        }






        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {

            var type = await _mediator.Send(new DeleteType(id));
            return Ok(type);

        }




    }
}
