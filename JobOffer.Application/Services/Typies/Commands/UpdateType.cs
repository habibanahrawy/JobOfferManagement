

namespace JobOffer.Application.Services.Typies.Commands
{
    public record UpdateType(int id, string name) : IRequest<bool>;

}
