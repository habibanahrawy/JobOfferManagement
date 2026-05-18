
namespace JobOffer.Application.Services.Account.Commands
{
    public record RefreshToken(RefreshTokenDTO TokenDTO) : IRequest<AuthDTO>;
}
