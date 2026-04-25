

namespace JobOffer.Application.Services.Categories.Commands
{
    public record DeleteCategory(int id) : IRequest<bool>;
   
}
