

namespace JobOffer.Application.Features.Categories.Commands
{
    public record UpdateCategory(int id, string name) : IRequest<bool>;
   
}
