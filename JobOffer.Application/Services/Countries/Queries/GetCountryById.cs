

namespace JobOffer.Application.Services.Countries.Queries
{
    public record GetCountryById(int id) : IRequest<CountryDTO>;
}
