

namespace JobOffer.Application.Services.Cities.Queries
{
    public record GetCityById(int id) : IRequest<CityDTO>;
}
