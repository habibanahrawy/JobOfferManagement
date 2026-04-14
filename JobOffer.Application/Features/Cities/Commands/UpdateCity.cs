

namespace JobOffer.Application.Features.Cities.Commands
{
    public record UpdateCity(int id , string name , int CountryId) : IRequest<bool>;
}
