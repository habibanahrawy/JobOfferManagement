

namespace JobOffer.Application.Services.Typies.Commands
{
    public record DeleteType(int id) : IRequest<bool>; 
  
}
