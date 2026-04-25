

namespace JobOffer.Application.Services.Typies.Commands
{
    public record CreateType(string name) : IRequest<TypeDTO>;
}
