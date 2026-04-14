

namespace JobOffer.Application.Features.Typies.Commands
{
    public record UpdateType(int id, string name) : IRequest<bool>;

}
