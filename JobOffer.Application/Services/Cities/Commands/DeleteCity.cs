

namespace JobOffer.Application.Services.Cities.Commands
{
    public record DeleteCity(int id) : IRequest<bool>;
}
