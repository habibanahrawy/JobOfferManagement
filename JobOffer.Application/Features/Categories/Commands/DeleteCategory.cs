

namespace JobOffer.Application.Features.Categories.Commands
{
    public record DeleteCategory(int id) : IRequest<bool>;
   
}
