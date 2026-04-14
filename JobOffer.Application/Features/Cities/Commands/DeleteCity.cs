

namespace JobOffer.Application.Features.Cities.Commands
{
    public record DeleteCity(int id) : IRequest<bool>;
}
