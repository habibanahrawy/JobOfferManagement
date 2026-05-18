
namespace JobOffer.Application.Services.Account.Commands
{
    public record ResetPass(ResetPassDTO PassDTO) : IRequest<bool>;
}
