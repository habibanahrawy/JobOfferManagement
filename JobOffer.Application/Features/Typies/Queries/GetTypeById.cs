

namespace JobOffer.Application.Features.Typies.Queries
{
    public record GetTypeById(int id) : IRequest<TypeDTO?>;
}
