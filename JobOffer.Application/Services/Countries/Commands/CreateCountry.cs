

namespace JobOffer.Application.Services.Countries.Commands
{
    public record CreateCountry(string name) : IRequest<CountryDTO>;
}
