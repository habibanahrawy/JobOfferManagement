

namespace JobOffer.Application.Features.Countries.Commands
{
    public record CreateCountry(string name) : IRequest<CountryDTO>;
}
