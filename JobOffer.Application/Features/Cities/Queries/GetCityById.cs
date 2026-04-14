

namespace JobOffer.Application.Features.Cities.Queries
{
    public record GetCityById(int id) : IRequest<CityDTO>;
}
