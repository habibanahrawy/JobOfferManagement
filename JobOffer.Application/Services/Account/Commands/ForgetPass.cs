
namespace JobOffer.Application.Services.Account.Commands
{
    public record ForgetPass(string email) : IRequest<bool>;
}
