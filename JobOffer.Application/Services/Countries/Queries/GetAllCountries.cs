

namespace JobOffer.Application.Services.Countries.Queries
{
    public record GetAllCountries : IRequest<IEnumerable<CountryDTO>>;
}