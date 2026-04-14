

namespace JobOffer.Application.Features.Cities.Commands
{
    public record CreateCity(string name , int CountryId) : IRequest<CityDTO>;
}
