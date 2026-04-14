

namespace JobOffer.Application.Features.Categories.Commands
{
    public record CreateCategory(string name) : IRequest<CategoryDTO>;
   
}
