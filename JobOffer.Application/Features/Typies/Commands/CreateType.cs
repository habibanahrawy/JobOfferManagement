

namespace JobOffer.Application.Features.Typies.Commands
{
    public record CreateType(string name) : IRequest<TypeDTO>;
}
