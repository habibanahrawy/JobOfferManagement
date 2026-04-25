

namespace JobOffer.Application.Services.Cities.Queries
{
    public record GetAllCities : IRequest<IEnumerable<CityDTO>>;
}
