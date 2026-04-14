

namespace JobOffer.Application.Features.Countries.Commands
{
    public record UpdateCountry(int id , string name) : IRequest<bool>;
}
