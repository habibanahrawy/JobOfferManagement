

namespace JobOffer.Application.Services.Typies.Queries
{
    public record GetTypeById(int id) : IRequest<TypeDTO?>;
}
