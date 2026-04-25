
namespace JobOffer.Application.Services.Cities.Handlers
{
    public class CreateCityHandler : BaseCreateHandler<CreateCity,City, CityDTO>
    {
        public CreateCityHandler(IUnitOfWork unitOfWork , IMapper mapper):base(unitOfWork, mapper)
        {
            
        }
    }
}
