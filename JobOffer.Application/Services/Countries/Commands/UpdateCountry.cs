

namespace JobOffer.Application.Services.Countries.Commands
{
    public record UpdateCountry(int id , string name) : IRequest<bool>;
}
