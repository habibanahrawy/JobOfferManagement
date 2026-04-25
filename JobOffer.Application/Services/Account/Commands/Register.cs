
namespace JobOffer.Application.Services.Account.Commands
{
    public record Register(RegisterDTO RegisterDTO) : IRequest<string>;
}
