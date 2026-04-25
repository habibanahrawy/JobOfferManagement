

namespace JobOffer.Application.Services.Countries.Handlers
{
    public class GetCountryByIdHandler : IRequestHandler<GetCountryById, CountryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCountryByIdHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CountryDTO> Handle(GetCountryById request, CancellationToken cancellationToken)
        {

            var country = await _unitOfWork.GetReposoitory<Country, int>().GetByIdAsync(request.id, cancellationToken);

            if (country == null) return null;

            return _mapper.Map<CountryDTO>(country);


        }
    }
}
