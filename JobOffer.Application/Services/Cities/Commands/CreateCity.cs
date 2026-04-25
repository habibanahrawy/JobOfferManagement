

namespace JobOffer.Application.Services.Cities.Commands
{
    public record CreateCity(string name , int CountryId) : IRequest<CityDTO>;
}
