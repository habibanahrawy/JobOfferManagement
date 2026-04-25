

namespace JobOffer.Application.Services.Categories.Commands
{
    public record UpdateCategory(int id, string name) : IRequest<bool>;
   
}
