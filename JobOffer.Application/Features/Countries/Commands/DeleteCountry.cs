
namespace JobOffer.Application.Features.Countries.Commands
{
    public record DeleteCountry(int id) : IRequest<bool>;
}
