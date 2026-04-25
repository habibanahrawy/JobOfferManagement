
namespace JobOffer.Application.Services.Categories.Commands
{
    public record CreateCategory(string name) : IRequest<CategoryDTO>;
   
}
