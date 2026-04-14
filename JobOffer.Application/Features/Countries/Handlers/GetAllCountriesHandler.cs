

namespace JobOffer.Application.Features.Countries.Handlers
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountries, IEnumerable<CountryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCountriesHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDTO>> Handle(GetAllCountries request, CancellationToken cancellationToken)
        {

            var country = await _unitOfWork.GetReposoitory<Country, int>().GetAllAsync();

            if (country == null) return null;

            return _mapper.Map<IEnumerable<CountryDTO>>(country);
            
        }
    }
}
