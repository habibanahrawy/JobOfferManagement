
namespace JobOffer.Application.Services.Typies.Handlers
{
    public class CreateTypeHandler : BaseCreateHandler<CreateType, Typess, TypeDTO>
    {
        public CreateTypeHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
    }
}
