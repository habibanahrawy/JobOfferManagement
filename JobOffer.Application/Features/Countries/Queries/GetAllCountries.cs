

namespace JobOffer.Application.Features.Countries.Queries
{
    public record GetAllCountries : IRequest<IEnumerable<CountryDTO>>;
}