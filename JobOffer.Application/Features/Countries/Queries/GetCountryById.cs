

namespace JobOffer.Application.Features.Countries.Queries
{
    public record GetCountryById(int id) : IRequest<CountryDTO>;
}
