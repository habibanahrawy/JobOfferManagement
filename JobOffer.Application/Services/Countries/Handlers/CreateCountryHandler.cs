

namespace JobOffer.Application.Services.Countries.Handlers
{
    public class CreateCountryHandler : BaseCreateHandler<CreateCountry, Country, CountryDTO>
    {
        public CreateCountryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
    }
}
