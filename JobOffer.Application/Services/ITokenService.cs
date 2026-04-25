
namespace JobOffer.Application.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(User user);
    }
}
