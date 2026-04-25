
namespace JobOffer.Application.Services.Countries.Commands
{
    public record DeleteCountry(int id) : IRequest<bool>;
}
