
namespace JobOffer.Application.Services.Account.Commands
{
    public record Login(LoginDTO LoginDTO) : IRequest<string>;
}
