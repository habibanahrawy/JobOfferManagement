
namespace JobOffer.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _mediator.Send(new GetAllCategories());
            return Ok(categories);
        }





        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _mediator.Send(new GetCategoryById(id));

            if(category == null) return NotFound();

            return Ok(category);
        }




        

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateCategory(CreateCategory createCategory)
        {
           var category = await _mediator.Send(createCategory);
           return Ok(category);
        }





        [HttpPost("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(int id , [FromBody] UpdateCategory updateCategory)
        {
            if (id != updateCategory.id) return NotFound();

            var category = await _mediator.Send(updateCategory);
            return Ok(category);
        }






        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var category = await _mediator.Send(new  DeleteCategory(id));
            return Ok(category);

        }

    }
}
